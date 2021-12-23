using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private DbSet<Location> _locations;
        private ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _locations = _dbContext.Locations;
        }

        public void Add(Location location)
        {
            _locations.Add(location);
        }

        public ICollection<Location> GetAll()
        {
            return _locations
                .Include(l => l.MeetingRooms)
                .ToList();
        }

        public ICollection<Location> GetAllByName(string name)
        {
            return _locations
                .Where(l => l.Name.Contains(name))
                .Include(l => l.MeetingRooms)
                .ToList();
        }

        public Location GetById(int id)
        {
            return _locations
                .Include(l => l.MeetingRooms)
                .SingleOrDefault(l => l.Id == id);
        }

        public Location GetLocationByName(string name)
        {
            return _locations
                .Include(l => l.MeetingRooms)
                .SingleOrDefault(l => l.Name.ToLower().Equals(name.ToLower()));
        }

        public void Remove(Location location)
        {
            _locations.Remove(location);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
