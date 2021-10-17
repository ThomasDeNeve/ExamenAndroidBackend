using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Data
{
    public static class DataInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //Check if database has been seeded with data
            if(context.MeetingRooms.Any() && context.Locations.Any())
            {
                return;
            }

            //Initialize data here
        }
    }
}
