using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private DbSet<Seat> _seats;
        private ApplicationDbContext _dbContext;

        public SeatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _seats = _dbContext.Seats;
        }

        public void Add(Seat seat)
        {
            _seats.Add(seat);
        }

        public ICollection<Seat> GetAll()
        {
            return _seats
                .ToList();
        }

        public Seat GetById(int id)
        {
            return _seats
                //.Include(s => s.Price)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Remove(Seat seat)
        {
            _seats.Remove(seat);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
