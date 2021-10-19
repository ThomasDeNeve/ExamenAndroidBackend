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
        public override int Ocasionally { get; set; }
        public override int FixedDown { get; set; }
        public override int FixedUp { get; set; }
        public override int Fulltime { get; set; }
        public override int Halftime { get; set; }
        public override int Year { get; set; }

        public override int Evening { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int FullDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HalfDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int TwoHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}