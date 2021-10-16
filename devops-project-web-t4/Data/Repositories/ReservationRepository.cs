using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private DbSet<Reservation> _reservations;
        private ApplicationDbContext _dbContext;

        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reservations = _dbContext.Reservations;
        }

        public void Add(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public ICollection<Reservation> GetAll()
        {
            return _reservations
                .Include(r => r.Customer)
                .Include(r => r.Room)
                .Include(r => r.Seat)
                .ToList();
        }

        public Reservation GetById(int id)
        {
            return _reservations
                .Include(r => r.Customer)
                .Include(r => r.Room)
                .Include(r => r.Seat)
                .SingleOrDefault(r => r.Id == id);
        }

        public void Remove(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
