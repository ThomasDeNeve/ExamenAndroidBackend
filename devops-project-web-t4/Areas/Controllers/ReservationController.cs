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
            ICoworkRoomRepository coworkRoomRepository)
        {
            _coworkReservationRepository = coworkReservationRepository;
            _meetingroomReservationRepository = meetingroomReservationRepository;

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

        /*public List<int> GetSeatIdsReservedForDate(DateTime date)
        {
            ICollection<CoworkReservation> reservations = _coworkReservationRepository.GetAll();
            List<int> seatsReserved = reservations.Where(r => r.From == date).Select(r => r.Seat.Id).ToList();

            return seatsReserved;
        }

        public List<int> GetMeetingroomIdsReservedForDateTime(DateTime date)
        {
            ICollection<MeetingroomReservation> reservations = _meetingroomReservationRepository.GetAll();
            List<int> roomsReserved = reservations.Where(r => r.From == date).Select(r => r.MeetingRoom.Id).ToList();

            return roomsReserved;

        }*/
        
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
    }
}
