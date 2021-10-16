using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double PriceAfEnToe { get; set; }
        public double PriceHalftime { get; set; }
        public double PriceFulltime { get; set; }
        public double PriceFixedDown { get; set; }
        public double PriceFixedUp { get; set; }
        public double PriceYear { get; set; }
    }
}
