using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{
    public abstract class ReservationStrategy
    {
        public abstract void Reserve(Seat seat);
        public abstract void Reserve(Room room);

    }
}