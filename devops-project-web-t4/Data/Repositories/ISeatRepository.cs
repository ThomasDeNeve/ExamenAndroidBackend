using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ISeatRepository
    {
        public ICollection<Seat> GetAll();
        public Seat GetById(int id);
        public void Remove(Seat seat);
        public void Add(Seat seat);
        public void SaveChanges();
    }
}
