using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private DbSet<Subscription> _subscriptions;
        private ApplicationDbContext _dbContext;

        public SubscriptionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _subscriptions = _dbContext.Subscriptions;
        }
        public ICollection<Subscription> GetAll()
        {
            return _subscriptions.ToList();
        }

        public Subscription GetById(int id)
        {
            return _subscriptions
                .SingleOrDefault(s => s.SubscriptionId == id);
        }

        public Subscription GetByName(string name)
        {
            return _subscriptions
                .SingleOrDefault(s => s.Name.Equals(name));
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
