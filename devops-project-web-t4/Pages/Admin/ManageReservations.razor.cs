using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace devops_project_web_t4.Pages.Admin
{
    public partial class ManageReservations
    {
        [Inject]
        public IReservationController ReservationController { get; set; }


        private List<string> CoworkingTableHeaders = new List<string>()
        {
        "Van", "Tot", "Zaal", "StoelNummer", "Status", "Klant"
        };
        private List<string> MeetingroomsTableHeaders = new List<string>()
        {
        "Van", "Tot", "Vergaderzaal", "Status", "Klant"
        };

        private string _username;
        private bool _hasAdminRole;
        private List<MeetingroomReservation> _meetingroomReservationsList;
        private List<CoworkReservation> _coworkReservationsList;

        public ManageReservations()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthState.GetAuthenticationStateAsync();
            _username = state.User.Identity.Name;
            _hasAdminRole = state.User.IsInRole("Admin");

            _meetingroomReservationsList = ReservationController.GetMeetingroomReservations();
            _coworkReservationsList = ReservationController.GetCoworkReservations();
        }

        public List<List<string>> CoworkingGetTableData()
        {
            List<List<string>> coworkingTableData = new List<List<string>>();

            foreach (CoworkReservation res in _coworkReservationsList)
            {
                Areas.Domain.CoworkRoom room = ReservationController.GetCoworkRoomForSeat(res.Seat);
                string seatId = String.IsNullOrEmpty(res.Seat?.Id.ToString()) ? "/" : res.Seat?.Id.ToString();
                string states = res.IsConfirmed ? "Bevestigd" : "Geannuleerd";
                coworkingTableData.Add(new List<string>() { res.From.ToString(), res.From.ToString(), room.Name, seatId, states, res.Customer.Username });
            }

            return coworkingTableData;
        }

        public List<List<string>> MeetingroomsGetTableData()
        {
            List<List<string>> meetingroomTableData = new List<List<string>>();

            foreach (MeetingroomReservation res in _meetingroomReservationsList)
            {
                string roomName = String.IsNullOrEmpty(res.MeetingRoom?.Name) ? "/" : res.MeetingRoom?.Name;
                string states = res.IsConfirmed ? "Bevestigd" : "Geannuleerd";
                meetingroomTableData.Add(new List<string>() { res.From.ToString(), res.To.ToString(), roomName, states, res.Customer.Username });
            }

            return meetingroomTableData;
        }
    }
}
