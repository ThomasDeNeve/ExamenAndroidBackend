using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4.Areas.Controllers
{
    public class RoomController : IRoomController
    {
        private readonly ICoworkRoomRepository _coworkRoomRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly Location _locationHier;
        private readonly Location _locationKluizen;
        public RoomController(ICoworkRoomRepository cr, ILocationRepository lr)
        {
            _coworkRoomRepository = cr;
            _locationRepository = lr;
            _locationHier = _locationRepository.GetLocationByName("HIER");
            _locationKluizen = _locationRepository.GetLocationByName("Kluizen");
        }
        public ICollection<CoworkRoom> GetAllCoworkRooms()
        {
            return _coworkRoomRepository.GetAll();
        }

        public ICollection<CoworkRoom> GetAllCoworkRoomsHier()
        {
            return _coworkRoomRepository.GetAll().Where(cwr => cwr.LocationId == _locationHier.Id).ToList();
        }
        public ICollection<CoworkRoom> GetAllCoworkRoomsKluizen()
        {
            return _coworkRoomRepository.GetAll().Where(cwr => cwr.LocationId == _locationKluizen.Id).ToList();
        }


    }
}
