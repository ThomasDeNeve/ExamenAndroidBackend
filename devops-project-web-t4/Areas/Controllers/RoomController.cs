using devops_project_web_t4.Data.Repositories;

namespace devops_project_web_t4.Areas.Controllers
{
    public class RoomController : IRoomController
    {
        private readonly ICoworkRoomRepository _coworkRoomRepository;
        public RoomController(ICoworkRoomRepository cr)
        {
            _coworkRoomRepository = cr;
        }



    }
}
