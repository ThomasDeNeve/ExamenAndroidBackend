﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4_API.DataModels
{
    public class CoworkReservationModel
    {
        public int CustomerId { get; set; }
        public int SeatId { get; set; }
        public string From { get; set; }
    }
}
