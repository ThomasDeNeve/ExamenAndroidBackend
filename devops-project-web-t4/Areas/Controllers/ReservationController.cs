using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;

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

        public DateTime SelectedDate { get; set; }

        public void ConfirmReservation(int seatId, int customerId)
        {
            
            Reservation reservation = new()
            {
                From = SelectedDate,
                To = SelectedDate,
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
