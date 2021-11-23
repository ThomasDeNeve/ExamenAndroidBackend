using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using devops_project_web_t4.Areas.State;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierBureelGelijkvloers1svg
    {
        [Inject]
        private NavigationManager UriHelper { get; set; }
        [Inject]
        private ISeatController SeatController { get; set; }

        private List<int> _seatsReserved;
        private DateTime _selectedDate;

        [Parameter]
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                _seatsReserved = SeatController.GetSeatIdsReservedForDate(_selectedDate);

                StateHasChanged();
            }
        }

        protected override void OnInitialized()
        {
            _seatsReserved = SeatController.GetSeatIdsReservedForDate(StateContainer.SelectedDate);

            if (_seatsReserved != null)
            {
                foreach (int i in _seatsReserved)
                {
                    Console.WriteLine("plattegrond seat" + i + " reserved");
                }
            }

            StateContainer.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            StateContainer.OnChange -= StateHasChanged;
        }


        public void NavigateTo(int id)
        {
            UriHelper.NavigateTo("/coworking/reserveer/seatReservationForm/" + id, false);
        }
    }
}
