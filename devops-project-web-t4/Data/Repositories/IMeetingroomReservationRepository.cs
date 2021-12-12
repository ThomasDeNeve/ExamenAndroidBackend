using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IMeetingroomReservationRepository
    {
        public ICollection<MeetingroomReservation> GetAll();
        public MeetingroomReservation GetById(int id);
        public void Remove(MeetingroomReservation reservation);
        public void Add(MeetingroomReservation reservation);
        public void SaveChanges();
    }
}
