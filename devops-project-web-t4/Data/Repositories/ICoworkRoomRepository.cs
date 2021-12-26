using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ICoworkRoomRepository
    {
        public ICollection<CoworkRoom> GetAll();
        public Task<ICollection<CoworkRoom>> GetAllAsync();
        public CoworkRoom GetById(int id);
        public CoworkRoom GetBySeat(Seat seat);
        public void Remove(CoworkRoom coworkroom);
        public void Add(CoworkRoom coworkroom);
        public void SaveChanges();
    }
}
