using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devops_project_web_t4.Areas.Domain;

namespace devops_project_web_t4.Data.Repositories
{
    public interface IMeetingroomReservationRepository
    {
        /// <summary>Fetches all the meetingroom reservations from the database.</summary>
        public ICollection<MeetingroomReservation> GetAll();
        /// <summary>Fetches all the meetingroom reservations from the database for a specific customer. </summary>
        /// <param name="customerId">the left side operand.</param>
        public ICollection<MeetingroomReservation> GetAllByCustomerId(int customerId);
        /// <summary>Fetches one meetingroom reservation based on MeetingRoomReservationId.</summary>
        /// <param name="id">Id of the MeetingroomReservation object.</param>
        public MeetingroomReservation GetById(int id);
        /// <summary>Deletes the MeetingroomReservation from the database.</summary>
        /// <param name="reservation">The object that will be deleted.</param>
        public void Remove(MeetingroomReservation reservation);
        /// <summary>Adds the MeetingroomReservation to the database.</summary>
        /// <param name="reservation">The object that will be created.</param>
        public void Add(MeetingroomReservation reservation);
        public void SaveChanges();
    }
}
