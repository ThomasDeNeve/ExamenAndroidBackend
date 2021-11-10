using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace devops_project_web_t4.Areas.State
{
    public class StateContainer
    {
        private readonly SeatController _seatController;

        private DateTime _dateSelected = DateTime.Now;
        private List<int> _seatsReserved = new List<int>();

        public StateContainer(SeatController r)
        {
            _seatController = r;
            SelectedDate = DateTime.Now;
        }

        public DateTime SelectedDate
        {
            get => _dateSelected;
            set
            {
                _dateSelected = value;
                Console.WriteLine("selected date: " + value);

                _seatsReserved = _seatController.GetSeatIdsReservedForDate(_dateSelected);
                foreach (var seat in SeatsReserved)
                {
                    Console.WriteLine(seat);
                }

                NotifyStateChanged();
            }
        }

        public List<int> SeatsReserved
        {
            get => _seatsReserved;
            set
            {
                _seatsReserved = value;
                

                //NotifyStateChanged();

            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
