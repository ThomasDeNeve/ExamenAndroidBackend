using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string Place { get; set; }
        public List<MeetingRoom> MeetingRooms { get; set; } = new List<MeetingRoom>();
        public List<CoworkRoom> CoWorkRooms { get; set; } = new List<CoworkRoom>();

        public void AddMeetingRoom(MeetingRoom meetingRoom) => this.MeetingRooms.Add(meetingRoom);

        //Onderstaande methode staat nu in CoworkRoom
        //public void AddCoWorkSeat(Seat coWorkSeat) => this.CoWorkSeats.Add(coWorkSeat);
    }
}
