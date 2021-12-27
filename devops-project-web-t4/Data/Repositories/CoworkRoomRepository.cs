using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class CoworkRoomRepository : ICoworkRoomRepository
    {
        private DbSet<CoworkRoom> _coworkrooms;
        private ApplicationDbContext _dbContext;

        public CoworkRoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _coworkrooms = _dbContext.CoworkRooms;
        }

        public void Add(CoworkRoom coworkroom)
        {
            _coworkrooms.Add(coworkroom);
        }

        public ICollection<CoworkRoom> GetAll()
        {
            return _coworkrooms
                .Include(r => r.Seats)
                .ToList();
        }
        public async Task<ICollection<CoworkRoom>> GetAllAsync()
        {
            return await Task.FromResult(_coworkrooms
                .Include(r => r.Seats)
                .ToList());
        }
        public async Task<ICollection<CoworkRoom>> GetAllCoworkRoomsOnLocationAsync(Location location)
        {
            return await Task.FromResult(_coworkrooms
                .Include(r => r.Seats)
                .Where(cwr => cwr.LocationId == location.Id)
                .ToList());
        }

        public CoworkRoom GetById(int id)
        {
            return _coworkrooms
                .Include(r => r.Seats)
                .SingleOrDefault(r => r.Id == id);
        }

        public CoworkRoom GetBySeat(Seat seat)
        {
            return _coworkrooms
                .SingleOrDefault(r => r.Seats.Contains(seat));
        }

        public void Remove(CoworkRoom coworkroom)
        {
            _coworkrooms.Remove(coworkroom);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
