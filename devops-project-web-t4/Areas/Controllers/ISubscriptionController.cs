using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface ISubscriptionController
    {
        /// <summary>Finalizes a subsciption type for a user.</summary>
        /// <param name="subName">The type of subscription</param>
        /// <param name="userName">The name of the user</param>
        /// <param name="date">The day of the confirmation</param>
        public void ConfirmSubscription(string subName, string userName, DateTime? date = null);

        /// <summary>Get the subscription for a certain customer.</summary>
        /// <param name="customerName">The name of the customer</param>
        /// <param name="month">The month where the subscription is active.</param>
        public List<CustomerSubscription> GetCustomerSubscriptions(string customerName = null, DateTime? month = null);

        /// <summary>Check if the user has a valid subscription</summary>
        /// <param name="userName">The name of the user</param>
        public bool HasActiveSub(string userName, DateTime? date = null);
    }
}
