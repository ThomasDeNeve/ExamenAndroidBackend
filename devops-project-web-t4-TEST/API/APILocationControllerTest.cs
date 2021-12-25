using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data;
using devops_project_web_t4.Data.Repositories;
using devops_project_web_t4_API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace devops_project_web_t4_TEST
{
    public class APILocationControllerTest
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly LocationRepository _repo;
        private readonly LocationController _controller;

        public APILocationControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "testing");

            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            AddLocationsToDbContext();
            _repo = new LocationRepository(_dbContext);
            _controller = new LocationController(_repo);
        }

        [Fact]
        public void GetLocations_ShouldReturnTwoLocations()
        {
            var result = _controller.GetLocations();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetLocationsByNameHIER_ShouldReturnOneLocation()
        {
            string name = "HIER";
            var result = _controller.GetLocations(name);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetLocationsById1_ShouldReturnOneLocation()
        {
            int id = 1;
            var result = _controller.GetLocations(id);

            Assert.NotNull(result);
            Assert.Equal(1, result.Value.Id);
            Assert.Equal("HIER", result.Value.Name);
        }

        private void AddLocationsToDbContext()
        {
            if (_dbContext.Locations.Count() == 0)
            {
                var locationGent = new Location()
                {
                    Name = "HIER",
                    Street = "Hier ergens",
                    Number = 1,
                    PostalCode = "BE9000",
                    Place = "Gent",
                    //MeetingRooms = meetingRoomsHier,
                    //CoWorkRooms = coworkRoomsHier
                };
                var locationAalst = new Location()
                {
                    Name = "Kluizen",
                    Street = "Ergens anders",
                    Number = 1,
                    PostalCode = "BE9300",
                    Place = "Aalst",
                    //MeetingRooms = meetingRoomsKluizen,
                    //CoWorkRooms = coworkRoomsKluizen
                };

                _dbContext.Locations.Add(locationGent);
                _dbContext.Locations.Add(locationAalst);

                _dbContext.SaveChanges();
            }
        }
    }
}
