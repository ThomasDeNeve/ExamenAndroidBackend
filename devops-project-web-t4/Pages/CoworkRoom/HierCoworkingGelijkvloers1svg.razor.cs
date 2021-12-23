using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace devops_project_web_t4.Pages.CoworkRoom
{
    public partial class HierCoworkingGelijkvloers1svg
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

        private bool IsTaken { get; set; }

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
            UriHelper.NavigateTo("/coworking/reserveer/seatReservationForm/" + id + "/" + _selectedDate.ToString("yyyy-MM-dd"), false);
        }
    }
}
