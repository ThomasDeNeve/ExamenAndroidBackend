using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public abstract class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double priceFullDay { get; set; }
        public double priceHalfDay { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public Reservation Reservation { get; set; }
        public abstract void ReserveSeat(Seat seat);
        public abstract void ReserveRoom();
    }
}
