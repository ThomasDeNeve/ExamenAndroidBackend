/*using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_TEST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devops_project_web_t4_TEST.Controllers
{
    class ReservationControllerTest
    {
        private readonly DummyDbContext _context;
        private readonly Mock<IReservationRepository> _reservationRepository;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<ISeatRepository> _seatRepository;
        private readonly Mock<StateContainer> _stateContainer;
        private readonly ReservationController _reservationController;

        public ReservationControllerTest()
        {
            _context = new DummyDbContext();
            _reservationRepository = new Mock<IReservationRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _seatRepository = new Mock<ISeatRepository>();
            _stateContainer = new Mock<StateContainer>();
            _reservationController = new ReservationController(_stateContainer.Object, _reservationRepository.Object, _customerRepository.Object, _seatRepository.Object);
        }

        private void InitializeMockObjects()
        {
            _reservationRepository.Setup(r => r.Add());
        }
    }
}
*/