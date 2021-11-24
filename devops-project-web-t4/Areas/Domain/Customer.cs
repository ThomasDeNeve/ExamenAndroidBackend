using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Customer
    {
        private Subscription _subscription;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Firstname {get;set;}
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string BTW { get; set; }
        public string Tel { get; set; }

        public Subscription Subscription
        {
            set
            {
                if (value != null)
                {
                    _subscription = value;
                    DaysLeft = _subscription.Days;
                }
                else
                {
                    _subscription = value;
                }
            }
            get
            {
                return _subscription;
            }
        }

        public int DaysLeft { get; set; }
    }
}