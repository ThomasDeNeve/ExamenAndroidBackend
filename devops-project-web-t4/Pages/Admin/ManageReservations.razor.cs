using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Linq;

namespace devops_project_web_t4.Pages.Admin
{
    public partial class ManageReservations
    {
        [Inject]
        public IReservationController ReservationController { get; set; }


        private List<string> _coworkingTableHeaders = new List<string>()
        {
            "Van", "Tot", "Zaal", "StoelNummer", "Klant", "Actie"
        };
        private List<string> _meetingroomTableHeaders = new List<string>()
        {
            "Van", "Tot", "Vergaderzaal", "Klant", "Actie"
        };

        private string _username;
        private List<MeetingroomReservation> _meetingroomReservationsList;
        private List<CoworkReservation> _coworkReservationsList;

        private string _error;
        private string _message;

        private List<List<string>> _coworkingTableData = new List<List<string>>();
        private List<List<string>> _meetingroomTableData = new List<List<string>>();

        public bool BackLinkEnabledMR { get => _currentPageMR > 1 ? true : false; }
        public bool NextLinkEnabledMR { get => _currentPageMR < _numberOfPagesMR ? true : false; }

        public bool BackLinkEnabledCW { get => _currentPageCW > 1 ? true : false; }
        public bool NextLinkEnabledCW { get => _currentPageCW < _numberOfPagesCW ? true : false; }

        private int _currentPageMR = 1;
        private int _currentPageCW = 1;

        private int _numberOfPagesMR = 1;
        private int _numberOfPagesCW = 1;

        public int _recordsPerPage = 5;

        public ManageReservations()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthState.GetAuthenticationStateAsync();
            _username = state.User.Identity.Name;

            SelectRows();
        }

        private void SelectRows()
        {
            _meetingroomReservationsList = ReservationController.GetMeetingroomReservations().OrderByDescending(x => x.From).ThenByDescending(x => x.MeetingRoom.Name).ToList();
            _coworkReservationsList = ReservationController.GetCoworkReservations().OrderByDescending(x => x.From).ThenBy(x => x.SeatId).ToList();

            _numberOfPagesCW = _coworkReservationsList?.Count > 0 ? (int)Math.Ceiling((double)_coworkReservationsList?.Count / _recordsPerPage) : 1;
            _numberOfPagesMR = _meetingroomReservationsList?.Count > 0 ? (int)Math.Ceiling((double)_meetingroomReservationsList?.Count / _recordsPerPage) : 1;

            _coworkingTableData = new List<List<string>>();
            _meetingroomTableData = new List<List<string>>();
            CoworkingTableData();
            MeetingroomTableData();
        }

        public List<List<string>> CoworkingTableData()
        {
            int skipRecords = (_currentPageCW - 1) * _recordsPerPage;

            foreach (CoworkReservation res in _coworkReservationsList.Skip(skipRecords).Take(_recordsPerPage))
            {
                Areas.Domain.CoworkRoom room = ReservationController.GetCoworkRoomForSeat(res.Seat);
                string seatId = String.IsNullOrEmpty(res.Seat?.Id.ToString()) ? "/" : res.Seat?.Id.ToString();
                string from = res.From.Hour == 0 && res.From.Minute == 0 ? res.From.ToString("dd/MM/yyyy") : res.From.ToString("dd/MM/yyyy HH:mm");
                _coworkingTableData.Add(new List<string>() { res.Id.ToString(), from, from, room.Name, seatId, res.Customer.Username });
            }

            return _coworkingTableData;
        }

        public List<List<string>> MeetingroomTableData()
        {
            int skipRecords = (_currentPageMR - 1) * _recordsPerPage;
            
            foreach (MeetingroomReservation res in _meetingroomReservationsList.Skip(skipRecords).Take(_recordsPerPage))
            {
                string roomName = String.IsNullOrEmpty(res.MeetingRoom?.Name) ? "/" : res.MeetingRoom?.Name;
                string from = res.From.Hour == 0 && res.From.Minute == 0 ? res.From.ToString("dd-MM-yyyy") : res.From.ToString("dd/MM/yyyy HH:mm");
                string to = res.To.Hour == 0 && res.To.Minute == 0 ? res.To.ToString("dd-MM-yyyy") : res.To.ToString("dd/MM/yyyy HH:mm");
                _meetingroomTableData.Add(new List<string>() { res.Id.ToString(), from, to, roomName, res.Customer.Username });
            }

            return _meetingroomTableData;
        }

        private void CancelCoworkingReservation(string id)
        {
            try
            {
                int resId = int.Parse(id);
                ReservationController.CancelCoworkReservation(resId, _username);
                SetMessage("Reservatie werd succesvol geannuleerd.");
                SelectRows();
            }
            catch
            {
                SetError("Annuleren van reservatie gefaald.");
            }
        }

        private void CancelMeetingRoomReservation(string id)
        {
            try
            {
                int resId = int.Parse(id);
                ReservationController.CancelMeetingRoomReservation(resId);
                SetMessage("Reservatie werd succesvol geannuleerd.");
                SelectRows();
            }
            catch
            {
                SetError("Annuleren van reservatie gefaald.");
            }
        }

        private void PreviousPageMeetingroom()
        {
            _currentPageMR -= 1;
            SelectRows();
        }
        private void NextPageMeetingroom()
        {
            _currentPageMR += 1;
            SelectRows();
        }

        private void PreviousPageCoworking()
        {
            _currentPageCW -= 1;
            SelectRows();
        }
        private void NextPageCoworking()
        {
            _currentPageCW += 1;
            SelectRows();
        }

        private void SetError(string text)
        {
            _message = null;
            _error = text;
        }

        private void SetMessage(string text)
        {
            _error = null;
            _message = text;
        }
    }
}
