using System;
using System.Collections.Generic;

namespace devops_project_web_t4.Areas.Controllers
{
    public interface ISeatController
    {
        /// <summary>Fetches all seats that have been reserved, also the locked ones.</summary>
        /// <param name="date">The day. </param>
        public List<int> GetSeatIdsReservedForDate(DateTime date);
    }
}
