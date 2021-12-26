using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IMeetingRoomRepository
    {
        public ICollection<MeetingRoom> GetAll();
        public MeetingRoom GetById(int id);
        public void Remove(MeetingRoom Room);
        public void Add(MeetingRoom room);
        public void SaveChanges();
    }
}
