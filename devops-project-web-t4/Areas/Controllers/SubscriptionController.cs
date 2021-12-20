using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;

namespace devops_project_web_t4.Areas.Controllers
{
    public class SubscriptionController : ISubscriptionController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ICustomerSubscriptionRepository _customerSubscriptionRepository;

        public SubscriptionController(ICustomerRepository customerRepository, ISubscriptionRepository subscriptionRepository, ICustomerSubscriptionRepository customerSubscriptionRepository)
        {
            _customerRepository = customerRepository;
            _subscriptionRepository = subscriptionRepository;
            _customerSubscriptionRepository = customerSubscriptionRepository;
        }

        public void ConfirmSubscription(string subName, string userName)
        {
            Subscription sub = _subscriptionRepository.GetByName(subName);
            Customer customer = _customerRepository.GetByName(userName);
            //customer.AddSubscription(cs);

            DateTime from;
            DateTime to;

            if (sub.SubscriptionId == 6)
            {
                from = DateTime.Now;
                to = from.AddYears(1);
            }
            else
            {
                from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                to = from.AddMonths(1).AddSeconds(-1);
            }

            customer.CustomerSubscriptions.Add(
                new CustomerSubscription()
                {
                    Subscription = sub,
                    Customer = customer,
                    From = from,
                    To = to
                });

            _customerRepository.SaveChanges();
        }

        public bool HasActiveSub(string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);
            
            if (customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active && cs.From <= DateTime.Now && cs.To >= DateTime.Now) != null)
            {
                return true;
            }
            return false;
        }

        public List<CustomerSubscription> GetCustomerSubscriptions(string customerName = null, DateTime? month = null)
        {
            return _customerSubscriptionRepository.GetByCustomerAndMonth(customerName, month).ToList();
        }
    }
}