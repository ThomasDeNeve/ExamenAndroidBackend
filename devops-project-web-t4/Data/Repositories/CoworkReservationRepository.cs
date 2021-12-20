using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class CoworkReservationRepository : ICoworkReservationRepository
    {
        private DbSet<CoworkReservation> _reservations;
        private ApplicationDbContext _dbContext;

        public CoworkReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reservations = _dbContext.CoworkReservations;
        }

        public void Add(CoworkReservation reservation)
        {
            _reservations.Add(reservation);
        }

        public ICollection<CoworkReservation> GetAll()
        {
            return _reservations
                .Include(r => r.Customer)
                .Include(r => r.Seat)
                .ToList();
        }

        public ICollection<CoworkReservation> GetAllByCustomerId(int customerId)
        {
            return _reservations?
                .Include(r => r.Customer)
                .Include(r => r.Seat)
                .Where(r => r.Customer.CustomerId == customerId)
                .ToList();
        }

        public CoworkReservation GetById(int id)
        {
            return _reservations
                .Include(r => r.Customer)
                //.Include(r => r.MeetingRoom)
                .Include(r => r.Seat)
                .SingleOrDefault(r => r.Id == id);
        }

        public void Remove(CoworkReservation reservation)
        {
            _reservations.Remove(reservation);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
