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
        public Customer Customer { get; set; }
        public int CustumerId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
        //Verwijzing voor EF
        public Seat Seat { get; set; }
        public int SeatId { get; set; }
        //Verwijzing voor EF
        public MeetingRoom MeetingRoom { get; set;}
        public int RoomId { get; set; }

        [NotMapped] //Wordt hiermee niet opgenomen in de EF mapping
        public ReservationStrategy ReservationStrategy { get; set; }
        
        public bool IsConfirmed { get; set; }

        public void Confirm(Seat seat)
        {
            ReservationStrategy.Reserve(seat);
            IsConfirmed = true;
        }
        public void Confirm(Room room)
        {
            ReservationStrategy.Reserve(room);
            IsConfirmed = true;
        }
    }
}
