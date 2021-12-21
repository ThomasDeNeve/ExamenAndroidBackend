using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ICoworkReservationRepository
    {
        public ICollection<CoworkReservation> GetAll();
        public ICollection<CoworkReservation> GetAllByCustomerId(int customerId);
        public CoworkReservation GetById(int id);
        public void Remove(CoworkReservation reservation);
        public void Add(CoworkReservation reservation);
        public void SaveChanges();
        List<CoworkReservation> GetByDate(DateTime date);
    }
}
