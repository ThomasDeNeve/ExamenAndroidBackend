using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{
    public class MeetingroomPrice : Price
    {
        public override int Evening { get; set; }
        public override int FullDay { get; set; }
        public override int HalfDay { get; set; }
        public override int TwoHours { get; set; }
       
        public override int Ocasionally { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int FixedDown { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int FixedUp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Fulltime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Halftime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Year { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}