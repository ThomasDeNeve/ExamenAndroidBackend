using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class CoworkRoom : Room
    {
        /*
         * Hier gaan we de Strategy voor Reservation (in superklasse Room) instellen op ReservationAsCoworkingRoomStrategy()
         * En daarna via de gekozen Strategy de reservering uitvoeren.
         */

        /* public override void Reserve(Seat seat)
        {
            Reservation.ReservationStrategy = new ReservationAsCoworkingRoomStrategy();
            Reservation.ReservationStrategy.Reserve(seat);
        }*/

        /*public override void Reserve()
        {
            /*
             * Dit willen we (voorlopig) niet dus throw exception, eventueel later aan te passen naar custom exception
             * Later kan de klant ook wensen om een CoworkRoom in te zetten als vergaderzaal.
             * Ofwel extra Strategy NietMogelijkStrategy en daar de exception throwen.
             */
            //throw new NotImplementedException();

            //Reservation.ReservationStrategy = new ReservationAsMeetingRoom();
            //Reservation.ReservationStrategy.Reserve(this);
        //}
    }
}
