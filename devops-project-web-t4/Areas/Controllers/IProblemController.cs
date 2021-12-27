using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IProblemController
    {
        /// <summary>
        /// Posts a new problem notification
        /// </summary>
        /// <param name="problemDescription">Description of the problem</param>
        /// <param name="locationId">Id of the location</param>
        /// <param name="locationDescription">description of the location in the room</param>
        public void PostNewProblem(string problemDescription, int locationId, string locationDescription);
    }
}
