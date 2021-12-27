using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class CoworkingKluizenOverzicht
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


        protected async override void OnInitialized()
        {
            _coworkRooms = await RoomController.GetAllCoworkRoomsKluizenAsync();
        }
    }
}
