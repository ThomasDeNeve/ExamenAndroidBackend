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
    /// <summary>
    /// StateContainer. Holds an observable SelectedDate property so we can use the property wherever it's needed.
    /// </summary>
    public class StateContainer
    {
        private readonly ISeatController _seatController;

        private static DateTime _now = DateTime.Now;
        private DateTime _dateSelected = new DateTime(_now.Year, _now.Month, _now.Day, 0, 0,0);//DateTime.Now;
        private List<int> _seatsReserved = new List<int>();

        public StateContainer(ISeatController r)
        {
            _seatController = r;
            SelectedDate = new DateTime(_now.Year, _now.Month, _now.Day, 0, 0, 0);//DateTime.Now;
        }

        /// <summary>
        /// Passed on by HierDatepicker
        /// </summary>
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
            set => _seatsReserved = value;
        }

        public Action OnChange; //Func<Task>

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
