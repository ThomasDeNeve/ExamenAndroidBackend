using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Areas.State;
using devops_project_web_t4.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public class ProblemController : IProblemController
    {
        private readonly IProblemRepository _problemRepository;
        private readonly StateContainer _stateContainer;

        public ProblemController(StateContainer sc,
            IProblemRepository problemRepository
            )
        {
            _problemRepository = problemRepository;
            _stateContainer = sc;
        }

        public void PostNewProblem(string problemDescription, int locationId, string locationDescription)
        {
            Problem problem = new()
            {
                ProblemDescription = problemDescription,
                LocationId = locationId,
                LocationDescription = locationDescription
            };

            _problemRepository.Add(problem);
            _problemRepository.SaveChanges();
        }
    }
}
