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

        public void ReserveMeetingRoom(int roomId, DateTime from, DateTime to)
        {
            Room room = _roomRepository.GetById(roomId);

            Reservation reservation = new()
            {
                Customer = _currentCustomer,
                From = from,
                To = to,
                Room = room
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }

        public void ReserveSeat(int roomId, int seatId, DateTime from, DateTime to)
        {
            Room room = _roomRepository.GetById(roomId);
            Seat seat = room.Seats.FirstOrDefault(s => s.Id == seatId);

            Reservation reservation = new()
            {
                Customer = _currentCustomer,
                From = from,
                To = to,
                Seat = seat
            };

            _reservationRepository.Add(reservation);
            _reservationRepository.SaveChanges();
        }
    }
}