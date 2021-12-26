using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class CoworkingHierOverzicht
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IRoomController RoomController { get; set; }

        private ICollection<devops_project_web_t4.Areas.Domain.CoworkRoom> _coworkRooms;

        public void ShowDetail(int roomId)
        {
            NavigationManager.NavigateTo("/coworking/overzicht/" + roomId);
        }
        protected override void OnInitialized()
        {
            _coworkRooms = RoomController.GetAllCoworkRooms();
        }
    }
}
