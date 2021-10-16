using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private DbSet<Room> _rooms;
        private ApplicationDbContext _dbContext;

        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _rooms = _dbContext.Rooms;
        }

        public void Add(Room room)
        {
            _rooms.Add(room);
        }

        public ICollection<Room> GetAll()
        {
            return _rooms
                .Include(r => r.Seats)
                .Include(r => r.Reservation)
                .ToList();
        }

        public Room GetById(int id)
        {
            return _rooms
                .Include(r => r.Seats)
                .Include(r => r.Reservation)
                .SingleOrDefault(r => r.Id == id);
        }

        public void Remove(Room room)
        {
            _rooms.Remove(room);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
