using devops_project_web_t4.Areas.Domain;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace devops_project_web_t4_API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customer/ByName
        [HttpGet]
        [Route("ByName")]
        public Customer GetCustomerByName(string username)
        {
            Customer c = _customerRepository.GetByName(username);

            return c;
        }

        // GET: api/customer
        [HttpGet]
        public Customer GetCustomerById(int id)
        {
            Customer c = _customerRepository.GetById(id);

            return c;
        }

        // GET: api/customer/GetLoggedIn
        [HttpGet]
        [Route("GetLoggedIn")]
        public Customer GetLoggedInCustomer(string username)
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
                return customer;
            }

            return c;
        }
    }
}
