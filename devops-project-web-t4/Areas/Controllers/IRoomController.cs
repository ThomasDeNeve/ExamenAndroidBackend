using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IRoomController
    {
        ICollection<CoworkRoom> GetAllCoworkRooms();
        Task<ICollection<CoworkRoom>> GetAllCoworkRoomsAsync();
        ICollection<CoworkRoom> GetAllCoworkRoomsHier();
        ICollection<CoworkRoom> GetAllCoworkRoomsKluizen();
    }
}
