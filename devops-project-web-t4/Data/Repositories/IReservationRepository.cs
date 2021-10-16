using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IReservationRepository
    {
        public ICollection<Reservation> GetAll();
        public Reservation GetById(int id);
        public void Remove(Reservation reservation);
        public void Add(Reservation reservation);
        public void SaveChanges();
    }
}
