using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.Seat
{
    public partial class SeatReservationForm
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IReservationController Controller { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        //Nog input halen uit datepicker etc
        public void Confirm()
        {
            Controller.ConfirmReservation(Id, 1);
            _navigationManager.NavigateTo("/coworking/reserveer");

        }

        public void Cancel()
        {
            _navigationManager.NavigateTo("/coworking/reserveer");
        }
    }
}
