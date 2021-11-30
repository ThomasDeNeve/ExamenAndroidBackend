using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
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

        public ReservationController(IReservationRepository reservationRepository, ICustomerRepository customerRepository, ISeatRepository seatRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _seatRepository = seatRepository;

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

        [HttpPost]
        public ActionResult<Location> AddReservation(ReservationModel model)
        {
            Reservation reservation = new Reservation()
            {
                Customer = _customerRepository.GetById(model.CustomerId),
                Seat = _seatRepository.GetById(model.SeatId)
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();

            return Ok(reservation);
        }
    }
}