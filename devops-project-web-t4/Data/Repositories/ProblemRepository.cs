using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private DbSet<Problem> _problems;
        private ApplicationDbContext _dbContext;

        public ProblemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _problems = _dbContext.Problems;
        }
        public void Add(Problem problem)
        {
            _problems.Add(problem);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
