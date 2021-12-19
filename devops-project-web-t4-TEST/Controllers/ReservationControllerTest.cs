using devops_project_web_t4.Areas.Controllers;
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
        private readonly Mock<ICoworkReservationRepository> _coworkReservationRepository;
        private readonly Mock<IMeetingroomReservationRepository> _meetingRoomReservationRepository;
        private readonly Mock<IMeetingRoomRepository> _meetingRoomRepository;
        private readonly Mock<ICoworkRoomRepository> _coworkRoomRepository;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<ISeatRepository> _seatRepository;
        private readonly Mock<ISeatController> _seatController;
        private readonly StateContainer _stateContainer;
        private readonly ReservationController _reservationController;

        public ReservationControllerTest()
        {
            _context = new DummyDbContext();
            _coworkReservationRepository = new Mock<ICoworkReservationRepository>();
            _meetingRoomReservationRepository = new Mock<IMeetingroomReservationRepository>();
            _meetingRoomRepository = new Mock<IMeetingRoomRepository>();
            _coworkRoomRepository = new Mock<ICoworkRoomRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _seatRepository = new Mock<ISeatRepository>();
            _seatController = new Mock<ISeatController>();
            InitializeMockObjects();
            _stateContainer = new StateContainer(_seatController.Object);
            _reservationController = new ReservationController(_stateContainer, _coworkReservationRepository.Object, _meetingRoomReservationRepository.Object, _customerRepository.Object, _seatRepository.Object, _meetingRoomRepository.Object, _coworkRoomRepository.Object);
        }

        [Fact]
        public void TestConfirmReservationMeetingRoom()
        {
            CoworkReservation reservation = null;
            _coworkReservationRepository.Setup(r => r.Add(It.IsAny<CoworkReservation>())).Callback<CoworkReservation>(r => reservation = r);
            _customerRepository.Setup(r => r.GetByName("dummy")).Returns(_context.customer1);
            _reservationController.ConfirmCoworkReservation(1, "dummy");
            Assert.Equal(_context.customer1.Firstname, reservation.Customer.Firstname);
            Assert.Equal(_context.customer1.Lastname, reservation.Customer.Lastname);
            Assert.Equal(_context.customer1.Email, reservation.Customer.Email);
            Assert.Equal(_context.customer1.Tel, reservation.Customer.Tel);
            Assert.Equal(_context.seatsThePractice[0].Id, reservation.Seat.Id);
        }

        [Fact]
        public void TestForOps() //do not delete
        {
            string test = "yes";
            Assert.Equal("yes", test);
        }


        private void InitializeMockObjects()
        {
            _seatController.Setup(s => s.GetSeatIdsReservedForDate(_context.dateTimeNow)).Returns(new List<int> { 1, 2, 3 });
            _customerRepository.Setup(c => c.GetById(1)).Returns(_context.yves);
            _seatRepository.Setup(s => s.GetById(1)).Returns(_context.seatsThePractice[0]);
        }
    }
}
