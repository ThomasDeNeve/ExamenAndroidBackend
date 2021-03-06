using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project_web_t4.Areas.Domain
{
    public class CoworkRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public int LocationId { get; set; }

        //public void AddCoWorkSeat(Seat coWorkSeat) => this.Seats.Add(coWorkSeat);
    }
}
