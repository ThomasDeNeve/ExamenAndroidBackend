using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_API.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Identity.Client;

namespace devops_project_web_t4_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ICoworkReservationRepository _coworkReservationRepository;
        private readonly IMeetingroomReservationRepository _meetingRoomReservationRepository;

        private readonly ICustomerRepository _customerRepository;

        private readonly ISeatRepository _seatRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        private readonly CultureInfo _culture = new ("en-US");
        private readonly string format = "yyyy-M-dd HH:mm:ss";

        private const string STARTTIMEMORNING = "08:00:00";
        private const string ENDTIMEMORNING = "12:00:00";
        private const string STARTTIMEAFTERNOON = "13:00:00";
        private const string ENDTIMEAFTERNOON = "17:00:00";
        private const string ENDTIMEEVENING = "21:00:00";

        public ReservationController(
            ICoworkReservationRepository coworkReservationRepository,
            IMeetingroomReservationRepository meetingroomReservationRepository,

            ICustomerRepository customerRepository,

            ISeatRepository seatRepository,
            IMeetingRoomRepository meetingRoomRepository)
        {
            _coworkReservationRepository = coworkReservationRepository;
            _meetingRoomReservationRepository = meetingroomReservationRepository;

            _customerRepository = customerRepository;

            _seatRepository = seatRepository;
            _meetingRoomRepository = meetingRoomRepository;
        }

        //TODO: change get to api/reservations/seats (also change api call in android!)
        // GET: api/reservations
        [HttpGet]
        public IEnumerable<CoworkReservation> GetCoworkReservations()
        {
            return _coworkReservationRepository.GetAll();
        }

        // GET: api/reservations/meetingrooms
        [HttpGet("meetingrooms")]
        public IEnumerable<MeetingroomReservation> GetMeetingroomReservations()
        {
            return _meetingRoomReservationRepository.GetAll();
        }

        //TODO: change get to api/reservations/seat/{id} (also change api call in android!)
        // GET : api/reservations/{id}
        [HttpGet("{id}")]
        public ActionResult<CoworkReservation> GetCoworkReservation(int id)
        {
            CoworkReservation reservation = _coworkReservationRepository.GetById(id);
            return reservation == null ? NotFound() : reservation;
        }

        [HttpGet("meetingroom/{id}")]
        public ActionResult<MeetingroomReservation> GetMeetingroomReservation(int id)
        {
            MeetingroomReservation reservation = _meetingRoomReservationRepository.GetById(id);
            return reservation == null ? NotFound() : reservation;
        }

        // POST: api/reservation/cowork
        [HttpPost("seat")]
        public ActionResult<CoworkReservation> PostCoworkReservation(CoworkReservationModel model)
        {
            //Customer customer = _customerRepository.GetByName(userName);

            CoworkReservation reservation = new CoworkReservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId), //= customer
                Seat = _seatRepository.GetById(model.SeatId),
            };

            //customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active && cs.From <= DateTime.Now && cs.To >= DateTime.Now).ReservationsLeft -= 1;

            _coworkReservationRepository.Add(reservation);
            _coworkReservationRepository.SaveChanges();

            return Ok(reservation);
        }

        // POST: api/reservation/meetingroom
        [HttpPost("meetingroom")]
        public ActionResult<MeetingroomReservation> PostMeetingroomReservation(MeetingroomReservationModel model)
        {
            DateTime start = DateTime.ParseExact(model.From, format, _culture);
            DateTime end = DateTime.ParseExact(model.To, format, _culture);

            double price = 0.0;
            MeetingRoom room = _meetingRoomRepository.GetById(model.RoomId);

            switch (model.Timeslot)
            {
                case "Voormiddag" :
                    price = room.PriceHalfDay;
                    break;
                case "Namiddag" :
                    price = room.PriceHalfDay;
                    break;
                case "Volledige dag" :
                    price = room.PriceFullDay;
                    break;
                case "Avond" :
                    price = room.PriceEvening;
                    break;
            }

            //TODO add exception handling
            MeetingroomReservation reservation = new MeetingroomReservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                From = start,
                To = end,
                Price = price,
                IsConfirmed = true,
                MeetingRoom = room
            };

            try
            {
                _meetingRoomReservationRepository.Add(reservation);
                _meetingRoomReservationRepository.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                //Log error on duplicate reservation
            }
            
            return Ok("OK");
        }

        //GET: api/reservation/availablemeetingrooms
        [HttpGet("availablemeetingrooms")]
        public ActionResult<List<MeetingRoom>> GetAvailableMeetingrooms(int neededseats, int locationid, string datetimeStart, string datetimeEnd)
        {
            //SCUFFED code :( maar het werkt...

            ICollection<MeetingroomReservation> reservations = _meetingRoomReservationRepository.GetAll();
            ICollection<MeetingRoom> meetingRooms = new List<MeetingRoom>();

            //list of ids for rooms that are already reserved
            List<int> idsRoomsTaken = new List<int>();
            
            try
            {
                DateTime tempDateFrom = Convert.ToDateTime(datetimeStart, _culture);
                DateTime tempDateEnd = Convert.ToDateTime(datetimeEnd, _culture);

                //Only the date without time (used to retreive meetingroomids with a reservation for a full day)
                DateTime selectedDate = tempDateFrom.Date;

                DateTime fullDayStart = selectedDate;
                TimeSpan ts = new TimeSpan(8, 0, 0);
                fullDayStart = fullDayStart.Date + ts;

                DateTime fullDayEnd = selectedDate;
                ts = new TimeSpan(17, 0, 0);
                fullDayEnd = fullDayEnd.Date + ts;

                string startingTime = tempDateFrom.TimeOfDay.ToString();
                string endingTime = tempDateEnd.TimeOfDay.ToString();

                //HELE DAG
                if (startingTime.Equals(STARTTIMEMORNING) && endingTime.Equals(ENDTIMEAFTERNOON))
                {
                    //Here r.From.Date == selectedDate (tempDateFrom.Date), using only the date and not the time.
                    //This way meetingrooms reserved for mornings and afternoon are also retreived.
                    idsRoomsTaken = reservations.Where(r => r.From.Date == selectedDate).Select(r => r.MeetingRoom.Id).ToList();
                }
                else
                {
                    //VOORMIDDAG, reservaties voor een hele dag ook uit filteren
                    if (startingTime.Equals(STARTTIMEMORNING) && endingTime.Equals(ENDTIMEMORNING))
                    {
                        //fill idsRoomTaken with ids for rooms that have a reservation in the morning (between 08 and 12)
                        idsRoomsTaken = reservations.Where(r => r.From == tempDateFrom && r.To == tempDateEnd)
                            .Select(r => r.MeetingRoom.Id).ToList();

                        //get the ids for rooms that have a reservation for the entire day and add them to idsRoomsTaken
                        //These need to be filtered aswell: if there is a reservation for a room for half a day, it shouldn't be possible to reserve it for an entire day
                        List<int> idsFullDayReservation = reservations
                            .Where(r => r.From == fullDayStart && r.To == fullDayEnd).Select(r => r.MeetingRoom.Id)
                            .ToList();
                        idsRoomsTaken.AddRange(idsFullDayReservation);
                    }
                    else
                    {
                        //NAMIDDAG, reservaties voor een hele dag ook uit filteren
                        if (startingTime.Equals(STARTTIMEAFTERNOON) && endingTime.Equals(ENDTIMEAFTERNOON))
                        {
                            idsRoomsTaken = reservations.Where(r => r.From == tempDateFrom && r.To == tempDateEnd)
                                .Select(r => r.MeetingRoom.Id).ToList();

                            List<int> idsFullDayReservation = reservations
                                .Where(r => r.From == fullDayStart && r.To == fullDayEnd).Select(r => r.MeetingRoom.Id)
                                .ToList();
                            idsRoomsTaken.AddRange(idsFullDayReservation);
                        }
                        else
                        {
                            //AVOND
                            if (startingTime.Equals(ENDTIMEAFTERNOON) && endingTime.Equals(ENDTIMEEVENING))
                            {
                                idsRoomsTaken = reservations.Where(r => r.From == tempDateFrom && r.To == tempDateEnd)
                                    .Select(r => r.MeetingRoom.Id).ToList();
                            }
                        }
                    }
                }
                
                meetingRooms = _meetingRoomRepository.GetAll();
                //get the meetingrooms based on locationId and number of needed seats
                meetingRooms = meetingRooms.Where(m => m.LocationId == locationid && m.NumberOfSeats >= neededseats).ToList();

                //remove items from meetingrooms based on idsRoomsTaken
                foreach (int idroomtaken in idsRoomsTaken)
                {
                    meetingRooms.Remove(_meetingRoomRepository.GetById(idroomtaken));
                }
            }
            catch (Exception e)
            {
                //TODO: add logging
                Console.WriteLine("Error retreiving available rooms");
            }

            return meetingRooms.ToList();
        }
    }
}