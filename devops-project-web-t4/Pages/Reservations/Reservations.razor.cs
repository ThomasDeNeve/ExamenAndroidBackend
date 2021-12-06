using devops_project_web_t4.Areas.Domain;
using System.Collections.Generic;
using System;
using devops_project_web_t4.Areas.Controllers;
using Microsoft.AspNetCore.Components;

namespace devops_project_web_t4.Pages.Reservations
{
    public partial class Reservations
    {
        [Inject]
        public IReservationController ReservationController { get; set; }
        

        private List<string> TableHeaders = new List<string>()
        {
        "Van", "Tot", "Vergaderzaal", "Stoel"
        };

        //private List<Reservation> ReservationsList;

        public Reservations()
        {
            /*TODO remove initData() and uncomment next line*/
            //ReservationsList = ReservationController.GetReservations();

            //initData();
        }

        protected override void OnInitialized()
        {
            //ReservationsList = ReservationController.GetReservations();
        }

        public List<List<string>> GetTableData()
        {
            List<List<string>> tableData = new List<List<string>>();

            /*foreach (Reservation res in ReservationsList)
            {
                string roomName = String.IsNullOrEmpty(res.MeetingRoom?.Name) ? "/" : res.MeetingRoom?.Name;
                string seatId = String.IsNullOrEmpty(res.Seat?.Id.ToString()) ? "/" : res.Seat?.Id.ToString();
                tableData.Add(new List<string>() { res.From.ToString(), res.To.ToString(), roomName, seatId });
            }*/

            return tableData;
        }






        /*TODE DELETE ALL NEXT CODE WHEN DATA IS FETCHED FROM CONTROLLER*/
        



        private void initData()
        {
            /*Reservation rev1 = GetReservation(12, null, new DateTime(2021, 11, 22, 8, 0, 0), new DateTime(2021, 11, 22, 17, 0, 0));
            Reservation rev2 = GetReservation(9, null, new DateTime(2021, 11, 21, 8, 0, 0), new DateTime(2021, 11, 21, 17, 0, 0));
            Reservation rev3 = GetReservation(12, null, new DateTime(2021, 11, 20, 8, 0, 0), new DateTime(2021, 11, 20, 17, 0, 0));
            Reservation rev4 = GetReservation(2, "Vanachter", new DateTime(2021, 11, 10, 12, 0, 0), new DateTime(2021, 11, 10, 17, 0, 0));
            Reservation rev5 = GetReservation(29, "Ginter", new DateTime(2021, 11, 02, 8, 0, 0), new DateTime(2021, 11, 02, 12, 0, 0));
            rev4.Seat = null;
            rev5.Seat = null;

            List<Reservation> data = new List<Reservation> { rev1, rev2, rev3, rev4, rev5 };
            this.ReservationsList = data;*/
        }

        private Seat GetSeat(int id)
        {
            Seat seat = new Seat();
            seat.Id = id;
            return seat;
        }

        private Areas.Domain.MeetingRoom GetRoom(string name)
        {
            Areas.Domain.MeetingRoom room = new Areas.Domain.MeetingRoom();
            room.Name = name;
            return room;
        }

        /*private Reservation GetReservation(int seatId, string roomName, DateTime from, DateTime to)
        {
            Reservation reservation1 = new Reservation();
            reservation1.From = from;
            reservation1.To = to;
            reservation1.Seat = GetSeat(seatId);
            reservation1.MeetingRoom = GetRoom(roomName);
            return reservation1;
        }*/
    }
}
