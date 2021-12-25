using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DbSet<Customer> _customers;
        private ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _customers = _dbContext.Customers;
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public ICollection<Customer> GetAll()
        {
            return _customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _customers
                .Include(c => c.CustomerSubscriptions).ThenInclude(cs => cs.Subscription)
                .SingleOrDefault(c => c.CustomerId == id);

            /*return _customers
                .Include(c => c.Subscription)
                .SingleOrDefault(c => c.CustomerId == id);*/
        }

        public Customer GetByName(string username)
        {
            return _customers
                .Include(c => c.CustomerSubscriptions).ThenInclude(cs => cs.Subscription)
                //.Include(c => c.Subscription)
                .SingleOrDefault(c => c.Username == username);
        }

        public void Remove(Customer customer)
        {
            _customers.Remove(customer);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}