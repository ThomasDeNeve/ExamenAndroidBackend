using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Areas.Controllers
{
    public class ReservationController : IReservationController
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly StateContainer _stateContainer;
        
        /*[Inject]
        private StateContainer StateContainer { get; set; }*/

        public ReservationController(StateContainer sc, IReservationRepository reservationRepository, ICustomerRepository customerRepository, ISeatRepository seatRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _seatRepository = seatRepository;
            _stateContainer = sc;
        }

        //public DateTime SelectedDate { get; set; }

        public void ConfirmReservation(int seatId, int customerId)
        {
            
            Reservation reservation = new()
            {
                From = _stateContainer.SelectedDate,
                To = _stateContainer.SelectedDate,
                //To = SelectedDate,
                //Customer = _customerRepository.GetById(customerId)
                Customer = new Customer(){Email="Yves.Vanduynslager@voestalpine.com",Firstname="Yves",Lastname = "Vanduynslager", Tel="666"}
            };

            reservation.Seat = _seatRepository.GetById(seatId);

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }

        public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<Reservation> reservations = _reservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return seatsReserved;
        }
    }
}
