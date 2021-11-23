using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class SeatReservationForm
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IReservationController Controller { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        public void Confirm()
        {
            
                Controller.ConfirmReservation(Id, 1);
                _navigationManager.NavigateTo("/coworking/overzicht");
            
            /*catch (DbUpdateException e)
            {
                Console.WriteLine("Error while updating database!");
            }*/
        }

        public void Cancel()
        {
            _navigationManager.NavigateTo("/coworking/overzicht");
        }
    }
}
