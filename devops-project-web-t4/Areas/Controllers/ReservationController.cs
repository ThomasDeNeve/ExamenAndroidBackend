using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4.Migrations;

namespace devops_project_web_t4.Areas.Controllers
{
    public class ReservationController : IReservationController
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

        public void ConfirmReservation(DateTime from, DateTime to, int seatId, int customerId)
        {
            
            Reservation reservation = new()
            {
                From = from,
                To = to,
                //Customer = _customerRepository.GetById(customerId)
                Customer = new Customer(){Email="Yves.Vanduynslager@voestalpine.com",Firstname="Yves",Lastname = "Vanduynslager", Tel="666"}
            };

            reservation.Seats.Add(_seatRepository.GetById(seatId));

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }
    }
}
