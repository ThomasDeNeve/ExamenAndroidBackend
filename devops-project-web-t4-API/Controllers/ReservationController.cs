using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_API.DataModels;
using Microsoft.AspNetCore.Mvc;

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

        public ReservationController(ICoworkReservationRepository coworkReservationRepository,
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

        [HttpGet]
        public IEnumerable<CoworkReservation> GetReservations()
        {
            return _coworkReservationRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CoworkReservation> GetReservation(int id)
        {
            CoworkReservation reservation = _coworkReservationRepository.GetById(id);
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
        public ActionResult<CoworkReservation> PostMeetingroomReservation(MeetingroomReservationModel model)
        {
            //TODO add exception handling
            MeetingroomReservation reservation = new MeetingroomReservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                MeetingRoom = _meetingRoomRepository.GetById(model.RoomId),
            };

            _meetingRoomReservationRepository.Add(reservation);
            _meetingRoomReservationRepository.SaveChanges();

            return Ok(reservation);
        }

        //GET: api/reservation/seats_taken_for_date
        [HttpGet("seats_taken_for_date")]
        public ActionResult<List<int>> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<CoworkReservation> reservations = _coworkReservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return Ok(seatsReserved);
        }

        //GET: api/reservation/meetingrooms_taken_for_date
        [HttpGet("meetingrooms_taken_for_date")]
        public ActionResult<List<int>> GetMeetingroomIdsReservedForDateTime(DateTime date)
        {
            ICollection<MeetingroomReservation> reservations = _meetingRoomReservationRepository.GetAll();
            List<int> roomsReserved = reservations.Where(r => r.From == date).Select(r => r.MeetingRoom.Id).ToList();

            return Ok(roomsReserved);
        }
    }
}