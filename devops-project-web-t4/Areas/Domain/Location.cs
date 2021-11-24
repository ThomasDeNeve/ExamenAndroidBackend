using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Location
    {
        private List<MeetingRoom> _rooms;
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
            get => _rooms;
            set
            {
                AddLocationIdToMeetingRoom(value);
            }
        }

        public List<CoworkRoom> CoWorkRooms { get; set; } = new List<CoworkRoom>();

        public void AddMeetingRoom(MeetingRoom meetingRoom) => this.MeetingRooms.Add(meetingRoom);

        private void AddLocationIdToMeetingRoom(List<MeetingRoom> value)
        {
            List<MeetingRoom> tempList = new List<MeetingRoom>();
            foreach (MeetingRoom room in value)
            {
                MeetingRoom tempRoom = room;
                tempRoom.LocationId = this.Id;
                tempList.Add(tempRoom);
            }
            _rooms = tempList;
        }

        //Onderstaande methode staat nu in CoworkRoom
        //public void AddCoWorkSeat(Seat coWorkSeat) => this.CoWorkSeats.Add(coWorkSeat);
    }
}
