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
        private DbSet<CoworkSeat> _seats;
        private ApplicationDbContext _dbContext;

        public SeatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _seats = _dbContext.Seats;
        }

        public void Add(CoworkSeat seat)
        {
            _seats.Add(seat);
        }

        public ICollection<CoworkSeat> GetAll()
        {
            return _seats.ToList();
        }

        public CoworkSeat GetById(int id)
        {
            return _seats.SingleOrDefault(s => s.Id == id);
        }

        public void Remove(CoworkSeat seat)
        {
            _seats.Remove(seat);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
