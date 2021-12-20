using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ICustomerSubscriptionRepository
    {
        #region Methods
        public ICollection<CustomerSubscription> GetAll();
        public ICollection<CustomerSubscription> GetByCustomerAndMonth(string customerName = null, DateTime? month = null);
        public void SaveChanges();
        #endregion
    }
}
