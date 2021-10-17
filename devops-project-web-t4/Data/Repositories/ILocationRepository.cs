using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ILocationRepository
    {
        public ICollection<Location> GetAll();
        public Location GetById(int id);
        public void Remove(Location location);
        public void Add(Location location);
        public void SaveChanges();
        public ICollection<Location> GetAllByName(string name);
  }
}
