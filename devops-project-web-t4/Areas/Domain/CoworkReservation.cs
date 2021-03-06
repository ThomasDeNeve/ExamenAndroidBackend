using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project_web_t4.Areas.Domain
{
    public class CoworkReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime From { get; set; }
        //public DateTime To { get; set; }

        public Seat Seat { get; set; }

        //Needed to add index in db.
        public int SeatId { get; set; }
        //public MeetingRoom MeetingRoom { get; set;}
        public Customer Customer { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
