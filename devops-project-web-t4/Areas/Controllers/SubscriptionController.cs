using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;

namespace devops_project_web_t4.Areas.Controllers
{
    public class SubscriptionController : ISubscriptionController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        //private readonly ICustomerSubscriptionRepository _customerSubscriptionRepository;

        public SubscriptionController(ICustomerRepository customerRepository, ISubscriptionRepository subscriptionRepository/*, ICustomerSubscriptionRepository customerSubscriptionRepository*/)
        {
            _customerRepository = customerRepository;
            _subscriptionRepository = subscriptionRepository;
            //_customerSubscriptionRepository = customerSubscriptionRepository;
        }

        public void ConfirmSubscription(string subName, string userName)
        {
            Subscription sub = _subscriptionRepository.GetByName(subName);
            Customer customer = _customerRepository.GetByName(userName);

            /*CustomerSubscription cs = new CustomerSubscription()
            {
                Customer = customer,
                Subscription = sub,
            };*/

            //_customerSubscriptionRepository.Add(cs);
        }

        /*public int TotalSaldoForUser(string userName)
        {
            int saldo = 0;
            Customer c = _customerRepository.GetByName(userName);

            foreach (CustomerSubscription cs in c.SubscriptionsLink)
            {
                saldo += cs.Saldo;
            }

            return saldo;
        }*/
    }
}
