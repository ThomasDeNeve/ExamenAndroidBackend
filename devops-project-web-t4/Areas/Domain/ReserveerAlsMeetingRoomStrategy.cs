using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{
    public class ReservationAsMeetingRoomStrategy : ReservationStrategy
    {
        public override void Reserve(Seat seat)
        {
            //ReserveerRoom
            throw new NotImplementedException();
        }
        public override void Reserve(Room room)
        {
            //blijft
            throw new NotImplementedException();
        }
    }
}