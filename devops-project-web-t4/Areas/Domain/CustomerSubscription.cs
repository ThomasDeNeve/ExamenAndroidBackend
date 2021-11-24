using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class CustomerSubscription
    {
        public int CustomerId { get; set; }
        public int SubscriptionId { get; set; }
        public Customer Customer { get; set; }
        public Subscription Subscription { get; set; }

        public DateTime SubFrom { get; set; }
        public DateTime SubTo { get; set; }
    }
}
