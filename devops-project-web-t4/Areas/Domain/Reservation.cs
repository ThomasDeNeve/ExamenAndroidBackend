using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Reservation
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
        //Verwijzing voor EF
        public Seat Seat { get; set; }
        //Verwijzing voor EF
        public MeetingRoom MeetingRoom { get; set;}

        public ReservationStrategy ReservationStrategy { get; set; }
        
        public bool IsConfirmed { get; set; }

        public void Confirm(Seat seat)
        {
            ReservationStrategy.Reserve(seat);
        }
        public void Confirm(Room room)
        {
            ReservationStrategy.Reserve(room);
        }
    }
}
