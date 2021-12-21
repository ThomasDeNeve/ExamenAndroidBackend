using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface ISubscriptionController
    {
        public void ConfirmSubscription(string subName, string userName);
        public List<CustomerSubscription> GetCustomerSubscriptions(string customerName = null, DateTime? month = null);
        public bool HasActiveSub(string userName);
    }
}
