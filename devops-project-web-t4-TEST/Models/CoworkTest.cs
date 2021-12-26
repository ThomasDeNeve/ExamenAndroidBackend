
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4_TEST.Data;
using Xunit;

namespace devops_project_web_t4_TEST.Models
{
    public class CoworkTest
    {
        private CoworkRoom _coworkRoom;
        private DummyDbContext _context;
        public CoworkTest()
        {
            _context = new DummyDbContext();
            _coworkRoom = _context.bureel1;
        }

        [Fact(Skip = "niet meer van toepassing")]
        public void TestAddCoworkSeat()
        {
            Assert.Equal(4, _coworkRoom.Seats.Count);
            //_coworkRoom.AddCoWorkSeat(_context.coworkSeatsCoworking[0]);
            Assert.Equal(5, _coworkRoom.Seats.Count);
        }
    }
}

