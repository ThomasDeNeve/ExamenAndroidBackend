using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        private DbSet<MeetingRoom> _meetingrooms;
        private ApplicationDbContext _dbContext;

        public MeetingRoomRepository(ApplicationDbContext dbContext)
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
                //.Include(r => r.Seats)
                .ToList();
        }

        public MeetingRoom GetById(int id)
        {
            return _meetingrooms
                //.Include(r => r.Seats)
                .SingleOrDefault(r => r.Id == id);
        }

        public ICollection<MeetingRoom> GetByLocationId(int id)
        {
            return _meetingrooms
                .Where(m => m.LocationId == id).ToList();
        }

        public ICollection<MeetingRoom> GetByNeededSeats(int numberofseats)
        {
            return _meetingrooms
                .Where(m => m.NumberOfSeats >= numberofseats).ToList();
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
