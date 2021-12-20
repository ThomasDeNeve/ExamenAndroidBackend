using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface ICustomerController
    {
        public List<Customer> GetAll();
        public void MapAuth0User(string username);
    }
}
