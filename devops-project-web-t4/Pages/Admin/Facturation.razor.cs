using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Areas.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.Admin
{
    public partial class Facturation
    {
        [Inject]
        public ICustomerController CustomerController { get; set; }
        [Inject]
        public IReservationController ReservationController { get; set; }
        [Inject]
        public ISubscriptionController SubscriptionController { get; set; }


        private List<string> MeetingroomTableHeaders = new List<string>()
        {
        "Klant", "Van", "Tot", "Zaal", "Prijs"
        };
        private List<string> SubscriptionTableHeaders = new List<string>()
        {
        "Klant", "Van", "Tot", "Abonnement", "Prijs"
        };
        private Customer Customer { get; set; }
        private DateTime FacturationMonth { get; set; }
        private int PriceMeetingrooms
        {
            get => (int)_meetingroomReservationList.Sum(r => r.Price);
        }
        private int PriceSubscriptions
        {
            get => (int)_customerSubscriptionList.Sum(cs => cs.Subscription.Price);
        }
        private int PriceTotal
        {
            get => PriceMeetingrooms + PriceSubscriptions;
        }

        private string _username;
        private bool _hasAdminRole;
        private List<Customer> _customerList;
        private List<MeetingroomReservation> _meetingroomReservationList;
        private List<CustomerSubscription> _customerSubscriptionList;

        public Facturation()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthState.GetAuthenticationStateAsync();
            _username = state.User.Identity.Name;
            _hasAdminRole = state.User.IsInRole("Admin");
            FacturationMonth = DateTime.Now.Date;

            await Load();
        }

        protected async Task Load()
        {
            _customerList = CustomerController.GetAll();

            _meetingroomReservationList = ReservationController.GetConfirmedMeetingroomReservations(FacturationMonth, Customer?.Username);
            _customerSubscriptionList = await SubscriptionController.GetCustomerSubscriptionsAsync(Customer?.Username, FacturationMonth);
        }

        private void OnChangeCustomer(object value)
        {
            try
            {
                int intValue = (int)value;
                Customer = _customerList.SingleOrDefault(c => c.CustomerId == intValue);
            }
            catch
            {
                Customer = null;
            }
            Load();
        }

        void OnChangeDate(DateTime? value)
        {
            try
            {
                FacturationMonth = value.Value;
            }
            catch
            {
                FacturationMonth = DateTime.Now.Date;
            }
            Load();
        }
    }
}
