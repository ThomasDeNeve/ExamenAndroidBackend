using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ICustomerRepository
    {
        #region Methods
        public ICollection<Customer> GetAll();
        public Customer GetById(int id);
        public Customer GetByName(string username);
        public void Remove(Customer customer);
        public void Add(Customer customer);
        public void SaveChanges();
        #endregion
    }
}
