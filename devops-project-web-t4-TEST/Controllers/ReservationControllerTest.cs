/*
﻿using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_TEST.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devops_project_web_t4_TEST.Controllers
{
    public class ReservationControllerTest
    {
        private readonly DummyDbContext _context;
        private readonly Mock<IReservationRepository> _reservationRepository;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<ISeatRepository> _seatRepository;
        private readonly Mock<ISeatController> _seatController;
        private readonly StateContainer _stateContainer;
        private readonly ReservationController _reservationController;

        public ReservationControllerTest()
        {
            _context = new DummyDbContext();
            _reservationRepository = new Mock<IReservationRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _seatRepository = new Mock<ISeatRepository>();
            _seatController = new Mock<ISeatController>();
            InitializeMockObjects();
            _stateContainer = new StateContainer(_seatController.Object);
            _reservationController = new ReservationController(_stateContainer, _reservationRepository.Object, _customerRepository.Object, _seatRepository.Object);
        }

        [Fact]
        public void TestConfirmReservation()
        {
            Reservation reservation = null;
            _reservationRepository.Setup(r => r.Add(It.IsAny<Reservation>())).Callback<Reservation>(r => reservation = r);
            _reservationController.ConfirmReservation(1, 1);
            Assert.Equal(_context.yves.Firstname, reservation.Customer.Firstname);
            Assert.Equal(_context.yves.Lastname, reservation.Customer.Lastname);
            Assert.Equal(_context.yves.Email, reservation.Customer.Email);
            Assert.Equal(_context.yves.Tel, reservation.Customer.Tel);
            Assert.Equal(_context.seatsThePractice[0].Id, reservation.Seat.Id);
        }

        private void InitializeMockObjects()
        {
            _seatController.Setup(s => s.GetSeatIdsReservedForDate(_context.dateTimeNow)).Returns(new List<int> { 1, 2, 3 });
            _customerRepository.Setup(c => c.GetById(1)).Returns(_context.yves);
            _seatRepository.Setup(s => s.GetById(1)).Returns(_context.seatsThePractice[0]);
        }
    }
}
*/
