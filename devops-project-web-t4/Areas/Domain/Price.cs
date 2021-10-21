using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Domain
{
    public abstract class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public abstract int Evening { get; set; }

        public abstract int FullDay { get; set; }

        public abstract int HalfDay { get; set; }

        public abstract int TwoHours { get; set; }

        public abstract int Ocasionally { get; set; }

        public abstract int FixedDown { get; set; }

        public abstract int FixedUp { get; set; }

        public abstract int Fulltime { get; set; }

        public abstract int Halftime { get; set; }

        public abstract int Year { get; set; }
    }
}