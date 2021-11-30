using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4_API.DataModels
{
    public class ReservationModel
    {
        public int CustomerId { get; set; }
        public int SeatId { get; set; }
        public int RoomId { get; set; }
    }
}
