/*using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4_TEST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devops_project_web_t4_TEST.Models
{
    public class LocationTest
    {
        private readonly DummyDbContext _context;
        private Location _location;

        public LocationTest()
        {
            _context = new DummyDbContext();
        }

        [Fact]
        public void AddMeetingRoomToLocationTest()
        {
            _location = _context.locationAalst;
            Assert.Equal(4, _location.MeetingRooms.Count);
            _location.AddMeetingRoom(_context.hierVanvoor);
            Assert.Equal(5, _location.MeetingRooms.Count);
        }

        [Fact]
        public void CheckMeetingRoomIdIsCorrect()
        {
            _location = _context.locationGent;
            Assert.DoesNotContain(_location.MeetingRooms, r => r.Name.Equals("TestRoom"));
            MeetingRoom testRoom = new MeetingRoom
            {
                Name = "TestRoom",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250
            };
            Assert.Equal(0, testRoom.LocationId);
            _location.AddMeetingRoom(testRoom);
            Assert.Contains(_location.MeetingRooms, r => r.Name.Equals("TestRoom"));
            var room = _location.MeetingRooms.First(r => r.Name.Equals("TestRoom"));
            Assert.Equal(1, _location.Id);
            Assert.Equal(_location.Id, room.LocationId);
        }
    }
}
*/