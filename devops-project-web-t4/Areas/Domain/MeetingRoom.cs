using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class MeetingRoom
    {

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumberOfSeats { get; set; }

        public double PriceEvening { get; set; }

        public double PriceFullDay { get; set; }
        public double PriceHalfDay { get; set; }

        public double PriceTwoHours { get; set; }
        #endregion

        #region Methods

        #endregion
    }
}
