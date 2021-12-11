using System;
using System.Collections.Generic;
using System.Linq;
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

        private ICollection<devops_project_web_t4.Areas.Domain.MeetingRoom> _meetingRooms;

        protected override void OnInitialized()
        {
            _meetingRooms = LocationRepository.GetLocationByName("Hier").MeetingRooms;
        }

        public void ShowRoom(int roomId)
        {
            var selectedRoom = _meetingRooms.Single(room => room.Id == roomId);
            NavigationManager.NavigateTo("meetingrooms/hier/" + selectedRoom.Name.ToLower());
        }
    }
}
