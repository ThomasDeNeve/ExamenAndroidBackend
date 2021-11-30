using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class CustomerSubscription
    {
        private double _daysLeft;
        private int _reservationsLeft;
        private Subscription _subscription;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }

        public Customer Customer { get; set; }
        public Subscription Subscription
        {
            get
            {
                return _subscription;
            }
            set
            {
                _subscription = value;
                Active = true;
                ReservationsLeft = _subscription.MaxNumberOfReservations;
            }
        }

        public int CustomerId { get; set; }
        public int SubscriptionId { get; set; }

        public bool Active{ get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public double DaysLeft
        {
            get
            {
                return _daysLeft;
            }
            set
            {
                _daysLeft = (To - From).TotalDays;
            }
        }

        public int ReservationsLeft
        {
            get
            {
                return _reservationsLeft;
            }
            set
            {
                _reservationsLeft = value;

                if (_reservationsLeft == 0)
                {
                    Active = false;
                }
            }
        }
    }
}
