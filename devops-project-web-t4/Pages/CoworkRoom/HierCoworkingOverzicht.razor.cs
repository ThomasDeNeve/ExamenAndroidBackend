﻿using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierCoworkingOverzicht
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ICoworkRoomRepository CoworkRoomRepository { get; set; }

        private ICollection<devops_project_web_t4.Areas.Domain.CoworkRoom> _coworkRooms;

        public void ShowDetail(int roomId)
        {
            NavigationManager.NavigateTo("/coworking/overzicht/" + roomId);
        }


        protected override void OnInitialized()
        {
            _coworkRooms = CoworkRoomRepository.GetAll();
        }
    }
}