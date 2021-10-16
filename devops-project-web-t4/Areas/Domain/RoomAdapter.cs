using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{
    public class RoomAdapter : CoworkRoom
    {
        // De MeetingRoom die we een andere implementatie willen geven
        public MeetingRoom MeetingRoom { get; set; }

        /*
         * Hier gaan we de Strategy voor Reservation (in superklasse Room) instellen op ReservationAsCoworkingRoom()
         * En daarna via de gekozen Strategy de reservering uitvoeren.
         */
        public override void ReserveSeat(Seat seat)
        {
            Reservation.ReservationStrategy = new ReservationAsCoworkingRoomStrategy();
            Reservation.ReservationStrategy.Reserve(seat);
        }
    }
}