using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface ICustomerController
    {
        /// <summary>Fetches all the customers.</summary>
        public List<Customer> GetAll();

        /// <summary>Maps auth0 username (email) to our own database table Customer on first login.</summary>
        public void MapAuth0User(string username);
    }
}
