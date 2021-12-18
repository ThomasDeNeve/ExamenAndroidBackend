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
        //private DateTime? dateTimeFilter = null;
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
            _meetingRooms = LocationRepository.GetLocationByName("Hier").MeetingRooms;
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
            if (dateTimeSelected.HasValue && Capacity.HasValue)
            {
                _meetingRooms = ReservationController.GetAvailableMeetingRoomsOnDate(dateTimeSelected, _meetingRooms).Where(r => r.NumberOfSeats >= _capacity).ToList();
            }
            else if (Capacity.HasValue)
            {
                _meetingRooms = LocationRepository.GetLocationByName("Hier").MeetingRooms.Where(r => r.NumberOfSeats >= _capacity).ToList();
            }
            else if (dateTimeSelected.HasValue)
            {
                _meetingRooms = ReservationController.GetAvailableMeetingRoomsOnDate(dateTimeSelected, _meetingRooms);
            }
            else
            {
                OnInitialized();
            }
        }
    }
}
