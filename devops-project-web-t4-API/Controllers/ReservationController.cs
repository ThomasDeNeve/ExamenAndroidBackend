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
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        public ReservationController(IReservationRepository reservationRepository,
            ICustomerRepository customerRepository,
            ISeatRepository seatRepository,
            IMeetingRoomRepository meetingRoomRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _seatRepository = seatRepository;
            _meetingRoomRepository = meetingRoomRepository;

        }

        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {

            return _reservationRepository.GetAll();

        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = _reservationRepository.GetById(id);
            return reservation == null ? NotFound() : reservation;
        }

        // POST: api/reservation/cowork
        [HttpPost("seat")]
        public ActionResult<Reservation> AddCoworkReservation(ReservationModel model)
        {
            Reservation reservation = new Reservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                //Seat = _seatRepository.GetById(model.SeatId),
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();

            return Ok(reservation);
        }

        // POST: api/reservation/meetingroom
        [HttpPost("meetingroom")]
        public ActionResult<Reservation> AddMeetingroomReservation(ReservationModel model)
        {
            //TODO add exception handling
            Reservation reservation = new Reservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                MeetingRoom = _meetingRoomRepository.GetById(model.RoomId),
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();

            return Ok(reservation);
        }
    }
}