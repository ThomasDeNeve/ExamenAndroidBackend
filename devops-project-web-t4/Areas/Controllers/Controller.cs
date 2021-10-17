using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Controllers
{
    public class Controller
    {
        private Customer _currentCustomer;
        private Location _currentLocation;

        private MeetingRoom _currentRoom;
        private Seat _currentSeat;

        IReservationRepository _reservationRepository;
        ILocationRepository _locationRepository;
        IRoomRepository _roomRepository;

        public Controller(IReservationRepository reservationRepostitory, ILocationRepository locationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepostitory;
            _locationRepository = locationRepository;
            _roomRepository = roomRepository;
        }

        public void SelectLocation(int locationId)
        {
            _currentLocation = _locationRepository.GetById(locationId);
        }
        public void SelectRoom(int roomId)
        {
            _currentRoom = _currentLocation.MeetingRooms.FirstOrDefault(r => r.Id == roomId);
        }
        public void SelectSeat(int seatId)
        {
            _currentSeat = _currentRoom.Seats.FirstOrDefault(s => s.Id == seatId);
        }

        public void ReserveMeetingRoom(DateTime from, DateTime to)
        {
            Reservation reservation = new()
            {
                Customer = _currentCustomer,
                From = from,
                To = to,
                MeetingRoom = _currentRoom
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }

        public void ReserveSeats(List<Seat> seats, DateTime from, DateTime to)
        {
            Reservation reservation = new()
            {
                Customer = _currentCustomer,
                From = from,
                To = to,
                Seats = seats
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }
    }
}