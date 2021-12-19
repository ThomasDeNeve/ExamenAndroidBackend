using System;
using System.Collections.Generic;
using System.Linq;
using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class MeetingRoomHierOverzicht
    {
        [Inject]
        private ILocationRepository LocationRepository { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IReservationController ReservationController { get; set; }
        private ICollection<devops_project_web_t4.Areas.Domain.MeetingRoom> _meetingRooms;
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
            //var selectedRoom = _meetingRooms.Single(room => room.Id == roomId);
            NavigationManager.NavigateTo("meetingroom/" + roomId);
        }

        void OnChange(DateTime? value)
        {
            this.dateTimeSelected = value;
            RefreshMeetingRooms();
        }

        public void ResetFilters()
        {
            //reset meetingrooms to initial value
            Capacity = null;
            dateTimeSelected = null;
        }

        private void RefreshMeetingRooms()
        {
            _meetingRooms = ReservationController.GetAvailableMeetingRoomsWithFilters(dateTimeSelected, Capacity, "Hier");
        }
    }
}
