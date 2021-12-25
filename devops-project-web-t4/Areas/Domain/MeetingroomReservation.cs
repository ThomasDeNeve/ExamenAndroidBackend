using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project_web_t4.Areas.Domain
{
    public class MeetingroomReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int MeetingroomId { get; set; }
        public MeetingRoom MeetingRoom { get; set; }
        public Customer Customer { get; set; }
        public bool IsConfirmed { get; set; }

        //public string Timeslot { get; set; }
        public double Price { get; set; }
    }

}
