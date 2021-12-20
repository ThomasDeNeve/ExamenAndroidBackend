using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;

namespace devops_project_web_t4.Areas.Controllers
{
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            ICollection<Customer> customers = _customerRepository.GetAll();

            return customers.ToList();
        }

        public void MapAuth0User(string username)
        {
            Customer c = _customerRepository.GetByName(username);

            //if the user does not exist in our own database, add it
            if (c == null)
            {
                Customer customer = new Customer()
                {
                    Username = username
                };

                _customerRepository.Add(customer);
                _customerRepository.SaveChanges();
            }
        }
    }
}