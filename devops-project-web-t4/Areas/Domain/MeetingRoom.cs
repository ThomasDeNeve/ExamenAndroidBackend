using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class MeetingRoom : Room
    {
        public double PriceEvening { get; set; }
        public double PriceTwoHours { get; set; }

        /*
         * Hier gaan we de Strategy voor Reservation (in superklasse Room) instellen op ReservationAsMeetingRoomStrategy()
         * En daarna via deze gekozen Strategy de reservering uitvoeren.
         */
        public override void ReserveRoom()
        {
            Reservation.ReservationStrategy = new ReservationAsMeetingRoomStrategy();
            Reservation.ReservationStrategy.Reserve(this);
        }

        /*
         * Deze implementatie gebeurt door de RoomAdapter subklasse
         */
        public override void ReserveSeat(Seat seat)
        { }
    }
}
