using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace devops_project_web_t4.Areas.Controllers
{
    public class ReservationController : IReservationController
    {
        private readonly ICoworkReservationRepository _coworkReservationRepository;
        private readonly IMeetingroomReservationRepository _meetingroomReservationRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        private readonly StateContainer _stateContainer;

        public ReservationController(StateContainer sc,
            ICoworkReservationRepository coworkReservationRepository,
            IMeetingroomReservationRepository meetingroomReservationRepository,
            ICustomerRepository customerRepository,
            ISeatRepository seatRepository,
            IMeetingRoomRepository meetingroomRepository,
            ILocationRepository locationRepository)
        {
            _coworkReservationRepository = coworkReservationRepository;
            _meetingroomReservationRepository = meetingroomReservationRepository;
            _locationRepository = locationRepository;
            _customerRepository = customerRepository;

            _seatRepository = seatRepository;
            _meetingRoomRepository = meetingroomRepository;

            _stateContainer = sc;
        }

        public void ConfirmCoworkReservation(int seatId, string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);

            CoworkReservation reservation = new()
            {
                From = _stateContainer.SelectedDate,
                Customer = customer
            };

            reservation.Seat = _seatRepository.GetById(seatId);

            customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active).ReservationsLeft -= 1;

            _coworkReservationRepository.Add(reservation);
            _coworkReservationRepository.SaveChanges();
        }

        public void ConfirmMeetingRoomReservation(int roomId, string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);

            MeetingroomReservation reservation = new()
            {
                From = _stateContainer.SelectedDate,
                Customer = customer
            };

            reservation.MeetingRoom = _meetingRoomRepository.GetById(roomId);

            _meetingroomReservationRepository.Add(reservation);
            _meetingRoomRepository.SaveChanges();

        }

        public List<int> GetMeetingroomIdsReservedForDateTime(DateTime date)
        {
            return _meetingroomReservationRepository.GetAll().Where(r => r.From == date).Select(r => r.MeetingRoom.Id).ToList();
        }
        public List<MeetingRoom> GetAvailableMeetingRoomsWithFilters(DateTime? date, int? capacity, String location)
        {
            var rooms = _locationRepository.GetLocationByName(location).MeetingRooms;
            if(date.HasValue && capacity.HasValue)
            {
                var roomIdsReservedOnSelectedDate = GetMeetingroomIdsReservedForDateTime((DateTime)date);
                return rooms.Where(room => !roomIdsReservedOnSelectedDate.Any(r2 => r2 == room.Id) && room.NumberOfSeats >= capacity).ToList();
            }
            else if (capacity.HasValue)
            {
                return rooms.Where(r => r.NumberOfSeats >= capacity).ToList();
            }
            else if (date.HasValue)
            {
                var roomIdsReservedOnSelectedDate = GetMeetingroomIdsReservedForDateTime((DateTime)date);
                return rooms.Where(room => !roomIdsReservedOnSelectedDate.Any(r2 => r2 == room.Id)).ToList();
            }
            else
            {
                return rooms;
            }
        }

        /*public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<CoworkReservation> reservations = _coworkReservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return seatsReserved;
        }
        
        /*public List<Reservation> GetReservations()
        {
            return _reservationRepository.GetAll().ToList();
        }*/
    }
}
