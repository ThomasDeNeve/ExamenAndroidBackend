using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IRoomController
    {
          /// <summary>Fetches all the coworking rooms from the database in an asyncronoush way.</summary>
        Task<ICollection<CoworkRoom>> GetAllCoworkRoomsAsync();

        /// <summary>Fetches all the coworking rooms from HIER from the database.</summary>
        ICollection<CoworkRoom> GetAllCoworkRoomsHier();

        /// <summary>Fetches all the coworking rooms from KLUIZEN from the database.</summary>
        ICollection<CoworkRoom> GetAllCoworkRoomsKluizen();
    }
}
