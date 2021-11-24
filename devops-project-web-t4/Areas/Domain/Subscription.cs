using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<CustomerSubscription> CustomersLink { get; set; } = new List<CustomerSubscription>();
    }
}
