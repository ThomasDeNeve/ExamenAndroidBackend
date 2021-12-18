using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class MeetingRoomDetail
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        private IMeetingRoomRepository MeetingRoomRepository { get; set; }

        private devops_project_web_t4.Areas.Domain.MeetingRoom _currentRoom;
        private string _reserveer = "";

        protected override void OnInitialized()
        {
            _currentRoom = MeetingRoomRepository.GetById(Id);
            _reserveer = "Reserveer " + _currentRoom.Name;
        }

        public string NavigateToReserve(DateTime selectedDate)
        {
            
            return "/reserveermeetingroom/" + Id;
        }

        public void Dispose()
        {
            StateContainer.OnChange -= StateHasChanged;
        }



    }
}
