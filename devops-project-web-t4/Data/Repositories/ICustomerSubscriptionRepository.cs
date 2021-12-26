using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;

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
