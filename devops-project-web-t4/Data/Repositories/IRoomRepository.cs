using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IRoomRepository
    {
        public ICollection<Room> GetAll();
        public Room GetById(int id);
        public void Remove(Room Room);
        public void Add(Room room);
        public void SaveChanges();
    }
}
