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
            _customerSubscriptions = _dbContext.CustomerSubscriptions;
        }
        public ICollection<CustomerSubscription> GetAll()
        {
            return _customerSubscriptions.ToList();
        }

        public ICollection<CustomerSubscription> GetByCustomerAndMonth(string customerName = null, DateTime? month = null)
        {
            if (!string.IsNullOrEmpty(customerName) && month.HasValue)
            {
                DateTime monthStart = new DateTime(month.Value.Year, month.Value.Month, 1);
                DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);
                return _customerSubscriptions.Where(
                    cs => cs.Customer.Username == customerName 
                    && monthStart <= cs.To.Date && monthEnd >= cs.From
                ).Include(cs => cs.Subscription).ToList();
            }
            else if (!string.IsNullOrEmpty(customerName))
            {
                return _customerSubscriptions.Where(cs => cs.Customer.Username == customerName).Include(cs => cs.Subscription).ToList();
            }
            else if (month.HasValue)
            {
                DateTime monthStart = new DateTime(month.Value.Year, month.Value.Month, 1);
                DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);
                return _customerSubscriptions.Where(cs => monthStart <= cs.To.Date && monthEnd >= cs.From).Include(cs => cs.Subscription).ToList();
            }
            else
            {
                return _customerSubscriptions.Include(cs => cs.Subscription).ToList();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
