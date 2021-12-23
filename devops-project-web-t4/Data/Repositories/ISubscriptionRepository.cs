using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;

namespace devops_project_web_t4.Data.Repositories
{
    public interface ISubscriptionRepository
    {
        #region Methods
        public ICollection<Subscription> GetAll();
        public Subscription GetById(int id);
        public Subscription GetByName(string name);
        public void SaveChanges();
        #endregion
    }
}
