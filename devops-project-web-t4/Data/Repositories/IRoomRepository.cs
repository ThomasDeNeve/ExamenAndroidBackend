using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IRoomRepository
    {
        public ICollection<MeetingRoom> GetAll();
        public MeetingRoom GetById(int id);
        public void Remove(MeetingRoom Room);
        public void Add(MeetingRoom room);
        public void SaveChanges();
    }
}
