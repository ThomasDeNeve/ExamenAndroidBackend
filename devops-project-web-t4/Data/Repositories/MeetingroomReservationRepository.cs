using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4.Data.Repositories
{
    public class MeetingroomReservationRepository : IMeetingroomReservationRepository
    {
        private DbSet<MeetingroomReservation> _reservations;
        private ApplicationDbContext _dbContext;

        public MeetingroomReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reservations = _dbContext.MeetingroomReservations;
        }

        public void Add(MeetingroomReservation reservation)
        {
            _reservations.Add(reservation);
        }

        public ICollection<MeetingroomReservation> GetAll()
        {
            return _reservations?
                .Include(r => r.Customer)
                .Include(r => r.MeetingRoom)
                .ToList();
        }

        public ICollection<MeetingroomReservation> GetAllByCustomerId(int customerId)
        {
            return _reservations?
                .Include(r => r.Customer)
                .Include(r => r.MeetingRoom)
                .Where(r => r.Customer.CustomerId == customerId)
                .ToList();
        }

        public MeetingroomReservation GetById(int id)
        {
            return _reservations
                .Include(r => r.Customer)
                .Include(r => r.MeetingRoom)
                //.Include(r => r.Seat)
                .SingleOrDefault(r => r.Id == id);
        }

        public void Remove(MeetingroomReservation reservation)
        {
            _reservations.Remove(reservation);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
