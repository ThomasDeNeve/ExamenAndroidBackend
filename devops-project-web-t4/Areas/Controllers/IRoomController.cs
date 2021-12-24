using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IRoomController
    {
        ICollection<CoworkRoom> GetAllCoworkRooms();
        ICollection<CoworkRoom> GetAllCoworkRoomsHier();
        ICollection<CoworkRoom> GetAllCoworkRoomsKluizen();
    }
}
