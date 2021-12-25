using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project_web_t4.Areas.Domain
{
    public class Location
    {
        private List<MeetingRoom> _meetingRooms;
        private List<CoworkRoom> _coworkRooms;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string Place { get; set; }
        public List<MeetingRoom> MeetingRooms
        {
            get => _meetingRooms;
            set
            {
                AddLocationIdToMeetingRoom(value);
            }
        }

        public List<CoworkRoom> CoWorkRooms
        {
            get => _coworkRooms;
            set
            {
                AddLocationIdToCoworkRoom(value);
            }
        }

        public void AddMeetingRoom(MeetingRoom meetingRoom)
        {
            meetingRoom.LocationId = this.Id;
            this.MeetingRooms.Add(meetingRoom);
        }

        private void AddLocationIdToMeetingRoom(List<MeetingRoom> value)
        {
            List<MeetingRoom> tempList = new List<MeetingRoom>();
            foreach (MeetingRoom room in value)
            {
                MeetingRoom tempRoom = room;
                tempRoom.LocationId = this.Id;
                tempList.Add(tempRoom);
            }
            _meetingRooms = tempList;
        }
        private void AddLocationIdToCoworkRoom(List<CoworkRoom> value)
        {
            List<CoworkRoom> tempList = new List<CoworkRoom>();
            foreach (CoworkRoom room in value)
            {
                CoworkRoom tempRoom = room;
                tempRoom.LocationId = this.Id;
                tempList.Add(tempRoom);
            }
            _coworkRooms = tempList;
        }

        //Onderstaande methode staat nu in CoworkRoom
        //public void AddCoWorkSeat(Seat coWorkSeat) => this.CoWorkSeats.Add(coWorkSeat);
    }
}
