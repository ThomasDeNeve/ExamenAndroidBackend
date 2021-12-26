using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace devops_project_web_t4.Areas.Domain
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string BTW { get; set; }
        public string Tel { get; set; }


        public List<CustomerSubscription> CustomerSubscriptions { get; set; }

        public void AddSubscription(CustomerSubscription cs)
        {
            CustomerSubscriptions.Add(cs);
        }


        public bool HasActiveSubscription()
        {
            if (CustomerSubscriptions.FirstOrDefault(cs => cs.Active && cs.From <= DateTime.Now && cs.To >= DateTime.Now) != null)
            {
                return true;
            }

            return false;
        }
    }
}