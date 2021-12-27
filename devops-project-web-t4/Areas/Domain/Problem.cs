using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Problem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProblemId { get; set; }
        /// <summary>
        /// description of the problem
        /// </summary>
        public string ProblemDescription { get; set; }
        /// <summary>
        /// id of the location
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Descrition of the location in the room
        /// </summary>
        public string LocationDescription { get; set; }
        /// <summary>
        /// flags whether the problem is solved or not
        /// </summary>
        public bool Solved { get; set; }
        /// <summary>
        /// Comments on the solvingprogress
        /// </summary>
        public string CommentsOnSolvingProgress { get; set; }
    }
}
