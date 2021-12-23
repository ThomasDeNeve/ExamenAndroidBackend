using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class ReserveMeetingRoom
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
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
        private bool _showDiv = true;
        private bool _reservationFailed;
        private bool _reservationSucceeded;
        private string _message;

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

        private string GoBack()
        {
            return "/meetingroom/" + Id;
        }

        private string GoHome()
        {
            return "/";
        }

        private void Reserve()
        {
            _showDiv = false;
            var date = DateTime.Parse(Date);
            try
            {
                ReservationController.ConfirmMeetingRoomReservation(Id, _userName, date, TimeSlot, _price);
                _reservationSucceeded = true;
            }
            catch (InvalidOperationException e)
            {
                _reservationFailed = true;
                _message = e.Message;
            }
        }
    }
}
