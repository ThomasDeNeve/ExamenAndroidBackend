using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepository = locationRepo;
        }

        // GET: api/Location
        /// <summary>Get all locations ordered by name</summary>
        /// <param name="name">Optional filter: The name of the location</param>
        /// <returns>array of locations</returns>
        [HttpGet]
        public IEnumerable<Location> GetLocations(string name = null)
        {
            if (name == null)
            {
                return _locationRepository.GetAll().OrderBy(l => l.Name);
            }
            else
            {
                //get filtered results
                return _locationRepository.GetAllByName(name).OrderBy(l => l.Name);
            }
        }

        // GET: api/Location/{id}
        /// <summary>Get a location by giving an id</summary>
        /// <param name="id">The id of a location</param>
        /// <returns>a location object</returns>
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocations(int id)
        {
            Location location = _locationRepository.GetById(id);
            return location == null ? NotFound() : location;
        }

        /// <summary>
        /// Create a location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        /*[HttpPost]
        public ActionResult<Location> Create(Location location)
        {
            // Should we use DTO's?
            Location locationToCreate = new Location()
            {
                Name = location.Name,
                Place = location.Place,
                PostalCode = location.PostalCode,
                Street = location.Street,
                Number = location.Number
            };
            // ToDo: Make seperate calls for adding objects, and check if they exist before creating a new one.
            if (location.MeetingRooms?.Count > 0)
            {
                foreach (var room in location.MeetingRooms)
                {
                    locationToCreate.AddMeetingRoom(new MeetingRoom()
                    {
                        Name = room.Name,
                        //Price = price
                    });
                }
                if (location.CoWorkSeats?.Count > 0)
                {
                    foreach (var seat in location.CoWorkSeats)
                    {
                        SeatPrice price = new SeatPrice()
                        {
                            Ocasionally = seat.Price.Ocasionally,
                            FixedDown = seat.Price.FixedDown,
                            FixedUp = seat.Price.FixedUp,
                            Fulltime = seat.Price.Fulltime,
                            Halftime = seat.Price.Halftime,
                            Year = seat.Price.Year
                        };
                        locationToCreate.AddCoWorkSeat(new Seat()
                        {
                            Price = price
                        });
                    }
                }

                
            }
            _locationRepository.Add(locationToCreate);
            _locationRepository.SaveChanges();

            return Ok(location);
        }*/

        /// <summary>
        /// Delete a location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Location location = _locationRepository.GetById(id);

            if (location == null)
            {
                return NotFound();
            }
            _locationRepository.Remove(location);
            _locationRepository.SaveChanges();

            return NoContent();
        }
    }
}
