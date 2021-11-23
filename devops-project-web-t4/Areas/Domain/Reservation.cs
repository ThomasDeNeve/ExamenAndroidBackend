using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Seat Seat { get; set; }
        //Needed to add index in db.
        public int SeatId { get; set; }
        public MeetingRoom MeetingRoom { get; set;}
        public Customer Customer { get; set; }        
        public bool IsConfirmed { get; set; }
    }
}
