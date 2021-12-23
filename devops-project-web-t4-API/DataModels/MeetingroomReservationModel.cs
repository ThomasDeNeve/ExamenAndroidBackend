namespace devops_project_web_t4_API.DataModels
{
    public class MeetingroomReservationModel
    {
        public int CustomerId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int RoomId { get; set; }
        public string Timeslot { get; set; }
    }
}
