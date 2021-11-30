using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace devops_project_web_t4.Areas.Controllers
{
    public class ReservationController : IReservationController
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly StateContainer _stateContainer;

        public ReservationController(StateContainer sc, IReservationRepository reservationRepository, ICustomerRepository customerRepository, ISeatRepository seatRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _seatRepository = seatRepository;
            _stateContainer = sc;
        }

        public void ConfirmReservation(int seatId, string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);

            Reservation reservation = new()
            {
                From = _stateContainer.SelectedDate,
                To = _stateContainer.SelectedDate,
                Customer = customer
            };

            reservation.Seat = _seatRepository.GetById(seatId);

            customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active).ReservationsLeft -= 1;
            //customer.GetActiveSubscription().DaysLeft -= 1;
            
            
            //customer.DaysLeft -= 1;

            /*if (customer.DaysLeft == 0)
            {
                user.Subscription = null;
            }*/

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }

        public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<Reservation> reservations = _reservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return seatsReserved;
        }

        public List<Reservation> GetReservations()
        {
            return _reservationRepository.GetAll().ToList();
        }
    }
}
