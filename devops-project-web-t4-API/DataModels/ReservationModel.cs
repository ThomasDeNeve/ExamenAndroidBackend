using System;

namespace devops_project_web_t4_API.DataModels
{
    public class ReservationModel
    {
        public string Customer { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string RoomType { get; set; }
        public string Room { get; set; }
    }
}
