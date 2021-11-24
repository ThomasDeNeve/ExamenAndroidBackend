using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;

namespace devops_project_web_t4.Data.Repositories
{
    public class CustomerSubscriptionRepository : ICustomerSubscriptionRepository
    {
        private DbSet<CustomerSubscription> _customerSubscriptions;
        private ApplicationDbContext _dbContext;

        public CustomerSubscriptionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            //_customerSubscriptions = _dbContext.CustomerSubscriptions;
        }

        public void Add(CustomerSubscription cs)
        {
            _customerSubscriptions.Add(cs);
        }

        public ICollection<CustomerSubscription> GetAll()
        {
            return _customerSubscriptions.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
