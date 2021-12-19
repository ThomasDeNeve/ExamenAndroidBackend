using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class ReserveMeetingRoom
    {
        [Inject]
        public IReservationController ReservationController { get; set; }
        [Inject]
        public ISubscriptionController SubscriptionController { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Date { get; set; }
        [Parameter]
        public string TimeSlot { get; set; }


        private string _userName;
        private AuthenticationState _state;
        private devops_project_web_t4.Areas.Domain.MeetingRoom _room;
        private devops_project_web_t4.Areas.Domain.Location _location;
        private double _price;

        protected override async Task OnInitializedAsync()
        {
            _state = await AuthState.GetAuthenticationStateAsync();
            _userName = _state.User.Identity.Name;
            GetDetails();
            await base.OnInitializedAsync();
        }

        private bool HasSub()
        {
            return SubscriptionController.HasActiveSub(_userName);
        }

        private void GetDetails()
        {
            var list = ReservationController.ProposeReservation(HasSub(), Id, TimeSlot);
            _room = (devops_project_web_t4.Areas.Domain.MeetingRoom)list[0];
            _location = (devops_project_web_t4.Areas.Domain.Location)list[1];
            _price = (Double)list[2];
        }


    }
}
