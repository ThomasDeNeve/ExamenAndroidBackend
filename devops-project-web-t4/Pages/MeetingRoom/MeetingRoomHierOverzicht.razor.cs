using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class MeetingRoomHierOverzicht
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IReservationController ReservationController { get; set; }
        private ICollection<Areas.Domain.MeetingRoom> _meetingRooms;
        private DateTime? dateTimeSelected = null;
        private int? _capacity;
        private int? Capacity
        {
            get { return _capacity; }
            set
            {
                _capacity = value;
                RefreshMeetingRooms();
            }
        }

        protected override void OnInitialized()
        {
            RefreshMeetingRooms();
        }

        public void ShowRoom(int roomId)
        {
            NavigationManager.NavigateTo("meetingroom/" + roomId);
        }

        void OnChange(DateTime? value)
        {
            this.dateTimeSelected = value;
            RefreshMeetingRooms();
        }

        public void ResetFilters()
        {
            dateTimeSelected = null;
            Capacity = null;
        }

        private async void RefreshMeetingRooms()
        {
            _meetingRooms = await ReservationController.GetAvailableMeetingRoomsWithFiltersAsync(dateTimeSelected, Capacity, "Hier");
        }
    }
}
