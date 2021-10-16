using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devops_project_web_t4.Areas.Controllers
{
    public class Controller
    {
        private List<Location> Locations { get; set; } = new List<Location>();
        private Location _location;

        public void SelectLocation(int locationId)
        {
            _location = Locations.FirstOrDefault(l => l.Id == locationId);
        }

        /**
         * Reserveer meetingroom: standaard use case.
         * Haal de room op adhv gekozen locatie (list later ophalen uit db). adhv correcte id zal dit altijd een MeetingRoom zijn.
         * Reserveer de room (superklasse). Naargelang het subtype van Room (hier MeetingRoom) hebben we ander gedrag voor ReserveRoom();
         */
        public void ReserveMeetingRoom(int roomId)
        {
            Room room = _location.Rooms.FirstOrDefault(r => r.Id == roomId); // as MeetingRoom;
            room.ReserveRoom();
        }

        /*
         * Reserveer coworking seat: standaard use case.
         * haal de room op adhv gekozen locatie. adhv correcte id zal dit altijd een CoworkingRoomm zijn.
         * Reserveer de seat in de room. Naargelang het subtype (hier CoworkRoom) van Room hebben we ander gedrag voor ReserveSeat();
         */
        public void ReserveCoworkingSeat(int roomId, int seatId)
        {
            Room room = _location.Rooms.FirstOrDefault(r => r.Id == roomId); // as CoworkRoom;
            Seat seat = room.Seats.FirstOrDefault(s => s.Id == seatId);

            room.ReserveSeat(seat);
        }

        /**
         * Nu willen we toelaten dat een meetingroom kan worden ingeboekt als coworking. Dus hebben we nu een roomid EN een seatId nodig.
         * Een meetingroom is standaard niet te boeken als coworking. Dus mbv RoomAdapter passen we de MeetingRoom aan zodat die zich kan gedragen als een CoworkRoom.
         * De adapter (die erft van CoworkRoom) staat nu in voor de implementatie van ReserveSeat.
         */
        public void ReserveMeetingRoomAsCoworking(int roomid, int seatId)
        {
            RoomAdapter adapter = new()
            {
                MeetingRoom = _location.Rooms.FirstOrDefault(r => r.Id == roomid) as MeetingRoom
            };

            Seat seat = adapter.MeetingRoom.Seats.FirstOrDefault(s => s.Id == seatId);
            adapter.ReserveSeat(seat);
        }
    }
}