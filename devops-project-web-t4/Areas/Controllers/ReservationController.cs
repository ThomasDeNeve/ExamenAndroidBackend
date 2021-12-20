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
        private readonly ICoworkRoomRepository _coworkRoomRepository;

        private readonly StateContainer _stateContainer;

        public ReservationController(StateContainer sc,
            ICoworkReservationRepository coworkReservationRepository,
            IMeetingroomReservationRepository meetingroomReservationRepository,
            ICustomerRepository customerRepository,
            ISeatRepository seatRepository,
            IMeetingRoomRepository meetingroomRepository,
            ILocationRepository locationRepository,
            ICoworkRoomRepository coworkRoomRepository)
        {
            _coworkReservationRepository = coworkReservationRepository;
            _meetingroomReservationRepository = meetingroomReservationRepository;
            _locationRepository = locationRepository;
            _customerRepository = customerRepository;

            _seatRepository = seatRepository;
            _meetingRoomRepository = meetingroomRepository;
            _coworkRoomRepository = coworkRoomRepository;

            _stateContainer = sc;
        }

        public void ConfirmCoworkReservation(int seatId, string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);

            CoworkReservation reservation = new()
            {
                From = _stateContainer.SelectedDate,
                Customer = customer,
                IsConfirmed = true
            };

            reservation.Seat = _seatRepository.GetById(seatId);

            customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active).ReservationsLeft -= 1;

            _coworkReservationRepository.Add(reservation);
            _coworkReservationRepository.SaveChanges();
        }

        public void CancelCoworkReservation(int reservationId)
        {
            CoworkReservation reservation = _coworkReservationRepository.GetById(reservationId);
            reservation.IsConfirmed = false;

            _coworkReservationRepository.SaveChanges();
        }


        public void ConfirmMeetingRoomReservation(int roomId, string userName, DateTime date, string timeslot, double price)
        {
            if (MeetingRoomIsNotAvailable(roomId, date, timeslot))
                throw new InvalidOperationException("Deze vergaderzaal is niet beschikbaar op het gekozen moment.");

            Customer customer = _customerRepository.GetByName(userName);
            var room = _meetingRoomRepository.GetById(roomId);

            MeetingroomReservation reservation = new()
            {
                From = date,
                Customer = customer,
                MeetingRoom = room,
                MeetingroomId = room.Id,
                IsConfirmed = true,
                Price = price,
                Timeslot = timeslot
            };

            _meetingroomReservationRepository.Add(reservation);
            _meetingRoomRepository.SaveChanges();
        }

        public void CancelMeetingRoomReservation(int reservationId)
        {
            MeetingroomReservation reservation = _meetingroomReservationRepository.GetById(reservationId);
            reservation.IsConfirmed = false;

            _coworkReservationRepository.SaveChanges();
        }

        private bool MeetingRoomIsNotAvailable(int roomId, DateTime date, string timeslot)
        {
            return _meetingroomReservationRepository
                 .GetAll()
                 .Any(reservation => reservation.MeetingroomId == roomId
                 && reservation.From == date
                 && reservation.Timeslot.Equals(timeslot));
        }

        public List<int> GetMeetingroomIdsReservedForDateTime(DateTime date)
        {
            return _meetingroomReservationRepository.GetAll().Where(r => r.From == date).Select(r => r.MeetingRoom.Id).ToList();
        }
        public List<MeetingRoom> GetAvailableMeetingRoomsWithFilters(DateTime? date, int? capacity, String location)
        {
            var rooms = _locationRepository.GetLocationByName(location).MeetingRooms;
            if (date.HasValue && capacity.HasValue)
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
        public List<Object> ProposeReservation(bool hasSub, int meetingRoomId, string timeslot)
        {
            var room = _meetingRoomRepository.GetById(meetingRoomId);
            var location = _locationRepository.GetById(room.LocationId);
            var price = CalculatePrice(hasSub, room, timeslot);
            return new() { room, location, price };
        }

        private double CalculatePrice(bool hasSub, MeetingRoom meetingRoom, string timeslot)
        {
            double price = 0;
            switch (timeslot)
            {
                case "Volledige dag":
                    price = meetingRoom.PriceFullDay;
                    break;
                case "Voormiddag":
                case "Namiddag":
                    price = meetingRoom.PriceHalfDay;
                    break;
                case "Avond":
                    price = meetingRoom.PriceEvening;
                    break;
            }
            if (hasSub)
                price *= 0.85;
            return price;
        }
        
        public List<MeetingroomReservation> GetMeetingroomReservations(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return _meetingroomReservationRepository.GetAll().ToList();
            }
            
            Customer customer = _customerRepository.GetByName(userName);
            return _meetingroomReservationRepository.GetAllByCustomerId(customer.CustomerId).ToList();
        }
        
        public List<CoworkReservation> GetCoworkReservations(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return _coworkReservationRepository.GetAll().ToList();
            }

            Customer customer = _customerRepository.GetByName(userName);
            return _coworkReservationRepository.GetAllByCustomerId(customer.CustomerId).ToList();
        }

        public CoworkRoom GetCoworkRoomForSeat(Seat seat)
        {
            return _coworkRoomRepository.GetBySeat(seat);
        }
        
        /*public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<CoworkReservation> reservations = _coworkReservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();
            return seatsReserved;
        }*/
    }
}
