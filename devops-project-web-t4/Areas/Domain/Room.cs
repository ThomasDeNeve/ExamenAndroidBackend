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
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public Reservation Reservation { get; set; }
        #endregion

        #region Methods
        public abstract void ReserveSeat(Seat seat);
        public abstract void ReserveRoom();
        #endregion
    }
}
