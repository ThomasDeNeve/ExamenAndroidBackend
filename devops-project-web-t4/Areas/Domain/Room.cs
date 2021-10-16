using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public abstract class Room
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double PriceFullDay { get; set; }
        public double PriceHalfDay { get; set; }

        [NotMapped]
        public int NumberOfSeats => Seats.Count;

        public List<Seat> Seats { get; set; } = new List<Seat>();
        public Reservation Reservation { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}
