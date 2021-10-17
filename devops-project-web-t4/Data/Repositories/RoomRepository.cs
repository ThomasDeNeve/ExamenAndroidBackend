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
        private DbSet<MeetingRoom> _meetingrooms;
        private ApplicationDbContext _dbContext;

        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _meetingrooms = _dbContext.MeetingRooms;
        }

        public void Add(MeetingRoom meetingroom)
        {
            _meetingrooms.Add(meetingroom);
        }

        public ICollection<MeetingRoom> GetAll()
        {
            return _meetingrooms
                .Include(r => r.Seats)
                .ToList();
        }

        public MeetingRoom GetById(int id)
        {
            return _meetingrooms
                .Include(r => r.Seats)
                .SingleOrDefault(r => r.Id == id);
        }

        public void Remove(MeetingRoom meetingroom)
        {
            _meetingrooms.Remove(meetingroom);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
