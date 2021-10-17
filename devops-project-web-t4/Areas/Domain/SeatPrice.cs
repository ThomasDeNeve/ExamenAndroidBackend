using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{

    public class SeatPrice : Price
    {
        public int Ocasionally { get; set; }

        public int FixedDown { get; set; }

        public int FixedUp { get; set; }

        public int Fulltime { get; set; }

        public int Halftime { get; set; }

        public int Year { get; set; }
    }
}