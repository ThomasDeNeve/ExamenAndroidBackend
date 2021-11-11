using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;

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
