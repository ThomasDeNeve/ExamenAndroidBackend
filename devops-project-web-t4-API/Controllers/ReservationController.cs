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

        private readonly CultureInfo culture = new CultureInfo("en-US");
        private readonly string format = "yyyy-MM-dd HH:mm:ss";

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

            //customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active).ReservationsLeft -= 1;

            _coworkReservationRepository.Add(reservation);
            _coworkReservationRepository.SaveChanges();

            return Ok(reservation);
        }

        // POST: api/reservation/meetingroom
        [HttpPost("meetingroom")]
        public ActionResult<MeetingroomReservation> PostMeetingroomReservation(MeetingroomReservationModel model)
        {


            DateTime start = DateTime.ParseExact(model.From, format, culture);
            DateTime end = DateTime.ParseExact(model.To, format, culture);

            //TODO add exception handling
            MeetingroomReservation reservation = new MeetingroomReservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                From = start,
                To = end,
                MeetingRoom = _meetingRoomRepository.GetById(model.RoomId),
            };

            try
            {
                _meetingRoomReservationRepository.Add(reservation);
                _meetingRoomReservationRepository.SaveChanges();
            }
            catch (DbUpdateException e)
            {

            }
            

            return Ok(reservation);
        }

        //DateTime in Android meegeven als "0001-01-01T00:00:00"
        /*
        //UNUSED
        //GET: api/reservation/seats_taken_for_date
        [HttpGet("seats_taken_for_date")]
        public ActionResult<List<int>> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<CoworkReservation> reservations = _coworkReservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return Ok(seatsReserved);
        }

        //UNUSED
        //GET: api/reservation/meetingrooms_taken_for_date
        [HttpGet("meetingrooms_taken_for_date")]
        public ActionResult<List<int>> GetMeetingroomIdsReservedForDateTime(DateTime date)
        {
            ICollection<MeetingroomReservation> reservations = _meetingRoomReservationRepository.GetAll();
            List<int> roomsReserved = reservations.Where(r => r.From == date).Select(r => r.MeetingRoom.Id).ToList();

            return Ok(roomsReserved);
        }*/

        //GET: api/reservation/availablemeetingrooms
        [HttpGet("availablemeetingrooms")]
        public ActionResult<List<MeetingRoom>> GetAvailableMeetingrooms(int neededseats, int locationid, string datetimeStart, string datetimeEnd)
        {
            ICollection<MeetingroomReservation> reservations = _meetingRoomReservationRepository.GetAll();
            ICollection<MeetingRoom> meetingRooms = new List<MeetingRoom>();

            try
            {
                CultureInfo culture = new CultureInfo("en-US");
                DateTime tempDateFrom = Convert.ToDateTime(datetimeStart, culture);
                DateTime tempDateEnd = Convert.ToDateTime(datetimeEnd, culture);

                //TODO: build dateCompare?
                List<int> idsRoomsTaken = reservations.Where(r => r.From == tempDateFrom && r.To == tempDateEnd).Select(r => r.MeetingRoom.Id).ToList();

                meetingRooms = _meetingRoomRepository.GetAll();

                foreach (int idroomtaken in idsRoomsTaken)
                {
                    meetingRooms.Remove(_meetingRoomRepository.GetById(idroomtaken));
                }

                //filter based on location and number of needed seats
                meetingRooms = meetingRooms.Where(m => m.LocationId == locationid && m.NumberOfSeats >= neededseats).ToList();
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