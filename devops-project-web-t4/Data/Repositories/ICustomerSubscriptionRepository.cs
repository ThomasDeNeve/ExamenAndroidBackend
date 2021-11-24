using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ICustomerSubscriptionRepository
    {
        public void Add(CustomerSubscription cs);
        public ICollection<CustomerSubscription> GetAll();
        public void SaveChanges();
    }
}
