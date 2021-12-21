using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface IReservationController
    {
        public void ConfirmCoworkReservation(int seatId, string username);
        public void ConfirmMeetingRoomReservation(int roomId, string userName, DateTime date, string timeslot, double price);
        public List<int> GetMeetingroomIdsReservedForDateTime(DateTime date);
        public List<MeetingRoom> GetAvailableMeetingRoomsWithFilters(DateTime? date, int? capacity, String location);
        public List<Object> ProposeReservation(bool hasSub, int meetingRoomId, string timeslot);

        public void CancelCoworkReservation(int reservationId);
        public void CancelMeetingRoomReservation(int reservationId);

        //public List<int> GetSeatIdsReservedForDate(DateTime date);

        public List<CoworkReservation> GetCoworkReservations(string userName = null);

        public List<MeetingroomReservation> GetMeetingroomReservations(string userName = null);

        public CoworkRoom GetCoworkRoomForSeat(Seat seat);
    }
}
