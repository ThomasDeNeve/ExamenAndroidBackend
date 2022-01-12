using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_API.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace devops_project_web_t4_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ICoworkReservationRepository _coworkReservationRepository;
        private readonly IMeetingroomReservationRepository _meetingRoomReservationRepository;
        private readonly ICoworkRoomRepository _coworkRoomRepository;

        private readonly ICustomerRepository _customerRepository;

        private readonly ISeatRepository _seatRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        private readonly CultureInfo _culture = new("en-US");
        private readonly string format = "yyyy-M-dd HH:mm:ss";

        private const string STARTTIMEMORNING = "08:00:00";
        private const string ENDTIMEMORNING = "12:00:00";
        private const string STARTTIMEAFTERNOON = "13:00:00";
        private const string ENDTIMEAFTERNOON = "17:00:00";
        private const string ENDTIMEEVENING = "21:00:00";

        public ReservationController(
            ICoworkReservationRepository coworkReservationRepository,
            IMeetingroomReservationRepository meetingroomReservationRepository,
            ICoworkRoomRepository coworkRoomRepository,

            ICustomerRepository customerRepository,

            ISeatRepository seatRepository,
            IMeetingRoomRepository meetingRoomRepository)
        {
            _coworkReservationRepository = coworkReservationRepository;
            _meetingRoomReservationRepository = meetingroomReservationRepository;
            _coworkRoomRepository = coworkRoomRepository;

            _customerRepository = customerRepository;

            _seatRepository = seatRepository;
            _meetingRoomRepository = meetingRoomRepository;
        }

        //TODO: change get to api/reservations/seats (also change api call in android!)
        // GET: api/reservations
        [HttpGet]
        public IEnumerable<CoworkReservation> GetCoworkReservations()
        {
            try
            {
                return _coworkReservationRepository.GetAll();
            }
            catch
            {
                return null;
            }
        }

        // GET: api/reservations/meetingrooms
        [HttpGet("meetingrooms")]
        public IEnumerable<MeetingroomReservation> GetMeetingroomReservations()
        {
            try
            {
                return _meetingRoomReservationRepository.GetAll();
            }
            catch
            {
                return null;
            }
        }

        //TODO: change get to api/reservations/seat/{id} (also change api call in android!)
        // GET : api/reservations/{id}
        [HttpGet("{id}")]
        public ActionResult<CoworkReservation> GetCoworkReservation(int id)
        {
            try
            {
                CoworkReservation reservation = _coworkReservationRepository.GetById(id);
                return reservation == null ? NotFound() : reservation;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("meetingroom/{id}")]
        public ActionResult<MeetingroomReservation> GetMeetingroomReservation(int id)
        {
            try
            {
                MeetingroomReservation reservation = _meetingRoomReservationRepository.GetById(id);
                return reservation == null ? NotFound() : reservation;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //GET: api/reservation/coworkroom/{date}
        [HttpGet("coworkroom")]
        public ActionResult<List<CoworkReservation>> GetCoworkReservation(string date)
        {
            try
            {
                DateTime _date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                List<CoworkReservation> response = _coworkReservationRepository.GetByDate(_date);
                return response == null ? NotFound() : response;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("seat")]
        public ActionResult<CoworkReservation> PostCoworkReservation(CoworkReservationModel model)
        {
            try
            {
                Customer customer = _customerRepository.GetById(model.CustomerId);
                DateTime date = DateTime.ParseExact(model.From, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CoworkReservation reservation = new CoworkReservation()
                {
                    From = date,
                    Customer = customer,
                    IsConfirmed = true
                };
                reservation.Seat = _seatRepository.GetById(model.SeatId);

                try
                {
                    if (customer.CustomerSubscriptions.Count > 0)
                        customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active && cs.From <= date && cs.To >= date).ReservationsLeft -= 1;
                }
                catch (NullReferenceException) { }

                _coworkReservationRepository.Add(reservation);
                _coworkReservationRepository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }
            return Ok("Ok");
        }

        // POST: api/reservation/meetingroom
        [HttpPost("meetingroom")]
        public ActionResult<MeetingroomReservation> PostMeetingroomReservation(MeetingroomReservationModel model)
        {
            try
            {
                DateTime start = DateTime.ParseExact(model.From, format, _culture);
                DateTime end = DateTime.ParseExact(model.To, format, _culture);

                double price = 0.0;
                MeetingRoom room = _meetingRoomRepository.GetById(model.RoomId);

                if (MeetingRoomIsNotAvailable(room.Id, start, model.Timeslot))
                    return BadRequest();

                switch (model.Timeslot)
                {
                    case "Voormiddag":
                        price = room.PriceHalfDay;
                        break;
                    case "Namiddag":
                        price = room.PriceHalfDay;
                        break;
                    case "Volledige dag":
                        price = room.PriceFullDay;
                        break;
                    case "Avond":
                        price = room.PriceEvening;
                        break;
                }

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
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }

            return Ok("OK");
        }

        //GET: api/reservation/availablemeetingrooms
        [HttpGet("availablemeetingrooms")]
        public ActionResult<List<MeetingRoom>> GetAvailableMeetingrooms(int neededseats, int locationid, string datetimeStart, string datetimeEnd)
        {

            ICollection<MeetingRoom> meetingRooms = new List<MeetingRoom>();
            try
            {
                //SCUFFED code :( maar het werkt...

                ICollection<MeetingroomReservation> reservations = _meetingRoomReservationRepository.GetAll();
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
                    Console.WriteLine("Error retreiving available rooms");
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }

            return meetingRooms.ToList();
        }

        //GET: api/reservation/allreservations
        [HttpGet("allreservations")]
        public ActionResult<List<ReservationModel>> GetAllReservations(string username, RoomType roomType = RoomType.All)
        {
            Customer c = _customerRepository.GetByName(username);
            List<ReservationModel> reservations = new();

            try
            {
                // Get reservations for the user
                ICollection<MeetingroomReservation> meetingroomReservations = new List<MeetingroomReservation>();
                ICollection<CoworkReservation> coworkReservations = new List<CoworkReservation>();

                if (roomType == RoomType.All || roomType == RoomType.Vergaderzaal)
                {
                    meetingroomReservations = _meetingRoomReservationRepository.GetAllByCustomerId(c.CustomerId);
                }
                if (roomType == RoomType.All || roomType == RoomType.Coworking)
                {
                    coworkReservations = _coworkReservationRepository.GetAllByCustomerId(c.CustomerId);
                }

                // Convert MeetingroomReservation objects to ReservationModel objects
                foreach (MeetingroomReservation res in meetingroomReservations)
                {
                    reservations.Add(new ReservationModel()
                    {
                        Customer = c.Username,
                        From = res.From.ToString("yyyy-MM-dd HH:mm"),
                        To = res.To.ToString("yyyy-MM-dd HH:mm"),
                        Room = res.MeetingRoom.Name,
                        RoomType = "Vergader zaal"
                    });
                }

                // Convert CoworkReservation objects to ReservationModel objects
                foreach (CoworkReservation res in coworkReservations)
                {
                    CoworkRoom room = _coworkRoomRepository.GetBySeat(res.Seat);

                    reservations.Add(new ReservationModel()
                    {
                        Customer = c.Username,
                        From = res.From.ToString("yyyy-MM-dd"),
                        To = res.From.ToString("yyyy-MM-dd"),
                        Room = room.Name,
                        RoomType = RoomType.Coworking.ToString()
                    });
                }
            }
            catch
            {
                return BadRequest();
            }

            return reservations.OrderByDescending(x => x.From).ThenByDescending(x => x.To).ThenBy(x => x.Room).ToList();
        }

        private bool MeetingRoomIsNotAvailable(int roomId, DateTime date, string timeslot)
        {
            DateTime Start = date;
            TimeSpan tsStart = new();
            DateTime End = date;
            TimeSpan tsEnd = new();

            //"Volledige dag", "Voormiddag", "Namiddag", "Avond"
            switch (timeslot)
            {
                case "Voormiddag":
                    tsStart = new TimeSpan(8, 0, 0);
                    tsEnd = new TimeSpan(12, 0, 0);
                    break;
                case "Namiddag":
                    tsStart = new TimeSpan(13, 0, 0);
                    tsEnd = new TimeSpan(17, 0, 0);
                    break;
                case "Volledige dag":
                    tsStart = new TimeSpan(8, 0, 0);
                    tsEnd = new TimeSpan(17, 0, 0);
                    break;
                case "Avond":
                    tsStart = new TimeSpan(17, 0, 0);
                    tsEnd = new TimeSpan(21, 0, 0);
                    break;
            }

            Start = Start.Date + tsStart;
            End = End.Date + tsEnd;

            return _meetingRoomReservationRepository.GetAll()
                .Any(reservation => reservation.MeetingroomId == roomId
                && reservation.From <= End
                && reservation.To >= Start);
        }

        public enum RoomType
        {
            All,
            Coworking,
            Vergaderzaal
        }
    }
}