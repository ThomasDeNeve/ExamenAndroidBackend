using devops_project_web_t4.Areas.Domain;
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

            #region CoworkSeats
            var coworkSeatsHIER = new Seat[20];
            for(int i = 0; i < coworkSeatsHIER.Length; i++)
            {
                coworkSeatsHIER[i] = new Seat() { PriceAfEnToe=70,PriceHalftime=120,PriceFulltime=225,PriceFixedDown=295,PriceFixedUp=320,PriceYear=195}; // Price als aparte entiteit? teveel duplicate data
            }
            var coworkSeatsKluizen = new Seat[20];
            for (int i = 0; i < coworkSeatsKluizen.Length; i++)
            {
                coworkSeatsKluizen[i] = new Seat() { PriceAfEnToe = 70, PriceHalftime = 120, PriceFulltime = 225, PriceFixedDown = 295, PriceFixedUp = 320, PriceYear = 195 }; // Price als aparte entiteit? teveel duplicate data
            }
            #endregion

            #region MeetingRooms
            var seatsHierVanvoor = new Seat[8];
            for(int i = 0; i < seatsHierVanvoor.Length; i++)
            {
                seatsHierVanvoor[i] = new Seat();
            }
            var meetingRoomHierVanvoor = new MeetingRoom()
            {
                Name = "HIER.Vanvoor",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Seats = seatsHierVanvoor.ToList()
            };

            var seatsHierBoven = new Seat[14];
            for (int i = 0; i < seatsHierBoven.Length; i++)
            {
                seatsHierBoven[i] = new Seat();
            }
            var meetingRoomHierBoven = new MeetingRoom()
            {
                Name = "HIER.Boven",
                PriceHalfDay = 225,
                PriceEvening = 295,
                PriceFullDay = 355,
                Seats = seatsHierBoven.ToList()
            };

            var seatsHierGinder = new Seat[40];
            for (int i = 0; i < seatsHierGinder.Length; i++)
            {
                seatsHierGinder[i] = new Seat();
            }
            var meetingRoomHierGinder = new MeetingRoom()
            {
                Name = "HIER.Ginder",
                PriceHalfDay = 275,
                PriceEvening = 325,
                PriceFullDay = 395,
                Seats = seatsHierGinder.ToList()
            };

            var meetingrooms = new MeetingRoom[]
            {
                meetingRoomHierBoven,
                meetingRoomHierGinder,
                meetingRoomHierVanvoor
            };
            #endregion

            #region Locations
            var locationGent = new Location()
            {
                Name = "HIER",
                Street = "Hier ergens",
                Number = 1,
                PostalCode = "BE9000",
                Place = "Gent",
                MeetingRooms = meetingrooms.ToList(),
                CoWorkSeats = coworkSeatsHIER.ToList()
            };
            #endregion

            context.Locations.Add(locationGent);
            context.SaveChanges();
        }
    }
}
