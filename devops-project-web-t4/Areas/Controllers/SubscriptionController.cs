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

        public SubscriptionController(ICustomerRepository customerRepository, ISubscriptionRepository subscriptionRepository)
        {
            _customerRepository = customerRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public void ConfirmSubscription(string subName, string userName)
        {
            Subscription sub = _subscriptionRepository.GetByName(subName);
            Customer customer = _customerRepository.GetByName(userName);
            //customer.AddSubscription(cs);

            customer.CustomerSubscriptions.Add(
                new CustomerSubscription()
                {
                    Subscription = sub,
                    Customer = customer
                });

            _customerRepository.SaveChanges();
        }

        public bool HasActiveSub(string userName)
        {
            Customer customer = _customerRepository.GetByName(userName);
            
            if (customer.CustomerSubscriptions.FirstOrDefault(cs => cs.Active) != null)
            {
                return true;
            }
            return false;
        }
    }
}