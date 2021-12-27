using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace devops_project_web_t4.Pages.MeetingRoom
{
    public partial class MeetingRoomDetail
    {
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Date { get; set; }
        [Inject]
        private IMeetingRoomRepository MeetingRoomRepository { get; set; }

        private DateTime? dateTimeSelected = DateTime.Today + new TimeSpan(24, 0, 0);
        private devops_project_web_t4.Areas.Domain.MeetingRoom _currentRoom;
        private string _reserveer = "";
        private readonly List<String> choices = new() { "Volledige dag", "Voormiddag", "Namiddag", "Avond" };
        private string _selectedTimeslot = "Volledige dag";

        private readonly string _format = "yyyy-MM-dd";
        private CultureInfo _culture = CultureInfo.InvariantCulture;

        protected override void OnInitialized()
        {
            _currentRoom = MeetingRoomRepository.GetById(Id);
            _reserveer = "Reserveer " + _currentRoom.Name;

            if (DateTime.TryParseExact(Date, _format, _culture, DateTimeStyles.None, out DateTime initDate))
            {
                dateTimeSelected = initDate;
            }
        }

        public string NavigateToReserve()
        {
            var temp = (DateTime)dateTimeSelected;
            return "/reserveermeetingroom/" + Id + "/" + temp.ToString(_format) + "/" + _selectedTimeslot;
        }

        public void Dispose()
        {
            StateContainer.OnChange -= StateHasChanged;
        }

        private void OnChangeDate(DateTime? value)
        {
            this.dateTimeSelected = value;
        }
        private void OnChangeSelectList(object value)
        {
            _selectedTimeslot = value.ToString();
        }

    }
}
