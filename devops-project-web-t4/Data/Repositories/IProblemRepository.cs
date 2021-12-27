using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IProblemRepository
    {
        public void Add(Problem problem);
        public void SaveChanges();
    }
}
