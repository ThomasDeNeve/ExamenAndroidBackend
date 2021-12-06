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

        public List<int> GetSeatIdsReservedForDate(DateTime date);

        public List<Reservation> GetReservations();
    }
}
