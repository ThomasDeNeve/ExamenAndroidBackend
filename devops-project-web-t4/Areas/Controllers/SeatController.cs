using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Controllers
{
    public class SeatController : ISeatController
    {
        private Customer _currentCustomer;
        private Location _currentLocation;

        private MeetingRoom _currentRoom;
        private Seat _currentSeat;

        IReservationRepository _reservationRepository;
        ILocationRepository _locationRepository;
        IRoomRepository _roomRepository;

        public SeatController(IReservationRepository reservationRepository, ILocationRepository locationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _locationRepository = locationRepository;
            _roomRepository = roomRepository;
        }

        public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<Reservation> reservations = _reservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return seatsReserved;
        }
    }
}