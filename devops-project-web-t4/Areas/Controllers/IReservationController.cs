﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IReservationController
    {
        public void ConfirmCoworkReservation(int seatId, string username);
        public void ConfirmMeetingRoomReservation(int roomId, string userName);
    }
}
