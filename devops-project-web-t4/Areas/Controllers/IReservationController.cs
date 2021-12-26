using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IReservationController
    {
        /// <summary>Confirms a coworking reservation for a full day.</summary>
        /// <param name="seatId">The id of the to be reserved seat</param>
        /// <param name="username">The username of the customer reserving the seat</param>
        /// <param name="date">The day of the confirmation</param>
        public void ConfirmCoworkReservation(int seatId, string username, DateTime? date = null);

        /// <summary>Confirms a meetingroom reservation for a specified time.</summary>
        /// <param name="roomId">The id of the to be reserved meeting room</param>
        /// <param name="userName">The username of the customer reserving the seat</param>
        /// <param name="date">The day of the reservation</param>
        /// <param name="timeslot">The time of day for the reservation. (Before noon, afternoon)</param>
        /// <param name="price">The price for the meetingroom</param>
        public void ConfirmMeetingRoomReservation(int roomId, string userName, DateTime date, string timeslot, double price);

        /// <summary>Fetches the ids of the meeting rooms reserved for a certain day.</summary>
        /// <param name="date">The day to be checked.</param>
        public List<int> GetMeetingroomIdsReservedForDateTime(DateTime date);

        /// <summary>Fetched all available MeetingRoom objects with filter from database</summary>
        /// <param name="date">The day</param>
        /// <param name="capacity">How many seat need to be in the meeting room</param>
        /// <param name="location">One of the two locations</param>
        public List<MeetingRoom> GetAvailableMeetingRoomsWithFilters(DateTime? date, int? capacity, String location);

        /// <summary>Locks the meeting room.</summary>
        /// <param name="hasSub">True if the current customer has a subscription</param>
        /// <param name="meetingRoomId">The id of the to be locked meeting room</param>
        /// <param name="timeslot">The time of day</param>
        public List<Object> ProposeReservation(bool hasSub, int meetingRoomId, string timeslot);

        /// <summary>Cancels a coworking seat reservatoin</summary>
        /// <param name="reservationId">Id of the coworkingReservation</param>
        public void CancelCoworkReservation(int reservationId, string userName);

        /// <summary>Cancels a meeting room reservation.</summary>
        /// <param name="reservationId">The id of the meetingroom reservation</param>
        public void CancelMeetingRoomReservation(int reservationId);

        //public List<int> GetSeatIdsReservedForDate(DateTime date);

        /// <summary>Fetches all coworking reservations for a specified user</summary>
        /// <param name="userName">The name of the user.</param>
        public List<CoworkReservation> GetCoworkReservations(string userName = null);

        /// <summary>Fetchesx all meeting room reservations for a specified user</summary>
        /// <param name="userName">The name of the user.</param>
        public List<MeetingroomReservation> GetMeetingroomReservations(string userName = null);

        /// <summary>Fetches all the meeting room reservations within a certain month that are allready confirmed. (Not the locked ones)</summary>
        /// <param name="month">The month</param>
        /// <param name="userName">The name of the user</param>
        public List<MeetingroomReservation> GetConfirmedMeetingroomReservations(DateTime month, string userName = null);

        /// <summary>Fetches the room where the cowork seat is located by the seat.</summary>
        /// <param name="seat">The seat object.</param>
        public CoworkRoom GetCoworkRoomForSeat(Seat seat);
    }
}
