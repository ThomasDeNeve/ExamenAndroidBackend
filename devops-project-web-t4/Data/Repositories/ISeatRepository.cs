using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ISeatRepository
    {
        public ICollection<CoworkSeat> GetAll();
        public CoworkSeat GetById(int id);
        public void Remove(CoworkSeat seat);
        public void Add(CoworkSeat seat);
        public void SaveChanges();
    }
}
