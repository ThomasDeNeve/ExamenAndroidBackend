using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.Seat
{
    public partial class SeatLocationSelector
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private string Message = @" HIER. zit je samen met andere ondernemers aan één grote tafel. Een professionele stopplaats tussen twee bezoeken door.
Vergaderen met klanten, leveranciers of elk ander professioneel contact. Onze Cowork voorziet de kans te netwerken met andere ondernemers.
Koffie, water en thee zijn steeds inbegrepen.";


        public void NavigateToReserveSeat()
        {
            _navigationManager.NavigateTo("/coworking/reserveer", false);
        }
    }
}
