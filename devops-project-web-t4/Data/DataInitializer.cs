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
            #region CoworkRoomsAndSeats
            

            //voorlopig nog empty list
            List<CoworkRoom> coworkRoomsKluizen = new List<CoworkRoom>();

            List<CoworkRoom> coworkRoomsHier = new List<CoworkRoom>();

            CoworkRoom bureel1 = new CoworkRoom();
            CoworkRoom coworking = new CoworkRoom();
            CoworkRoom bureel2 = new CoworkRoom();

            var coworkSeatsBureel1 = new Seat[4];

            for (int i = 0; i < coworkSeatsBureel1.Length; i++)
            {
                coworkSeatsBureel1[i] = new Seat()
                {
                    PriceOcasionally = 70,
                    PriceHalftime = 120,
                    PriceFulltime = 225,
                    PriceFixedDown = 295,
                    PriceFixedUp = 320,
                    PriceYear = 195
                };
            }

            bureel1.Name = "Bureel 1";
            bureel1.Seats = coworkSeatsBureel1.ToList();

            var coworkSeatsCoworking = new Seat[6];

            for (int i = 0; i < coworkSeatsCoworking.Length; i++)
            {
                coworkSeatsCoworking[i] = new Seat()
                {
                    PriceOcasionally = 70,
                    PriceHalftime = 120,
                    PriceFulltime = 225,
                    PriceFixedDown = 295,
                    PriceFixedUp = 320,
                    PriceYear = 195
                };
            }

            coworking.Name = "Coworking";
            coworking.Seats = coworkSeatsCoworking.ToList();

            var coworkSeatsBureel2 = new Seat[3];

            for (int i = 0; i < coworkSeatsBureel2.Length; i++)
            {
                coworkSeatsBureel2[i] = new Seat()
                {
                    PriceOcasionally = 70,
                    PriceHalftime = 120,
                    PriceFulltime = 225,
                    PriceFixedDown = 295,
                    PriceFixedUp = 320,
                    PriceYear = 195
                };
            }

            bureel2.Name = "Bureel 2";
            bureel2.Seats = coworkSeatsBureel2.ToList();

            coworkRoomsHier.Add(bureel1);
            coworkRoomsHier.Add(bureel2);
            coworkRoomsHier.Add(coworking);
            #endregion

            #region MeetingRooms
            var seatsHierVanvoor = new Seat[8];
            for(int i = 0; i < seatsHierVanvoor.Length; i++)
            {
                seatsHierVanvoor[i] = new Seat();
            }
            var HierVanvoor = new MeetingRoom()
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
            var HierBoven = new MeetingRoom()
            {
                Name = "HIER.Boven",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Seats = seatsHierBoven.ToList()
            };

            var seatsHierGinder = new Seat[40];
            for (int i = 0; i < seatsHierGinder.Length; i++)
            {
                seatsHierGinder[i] = new Seat();
            }
            var HierGinder = new MeetingRoom()
            {
                Name = "HIER.Ginder",
                PriceHalfDay = 275,
                PriceEvening = 325,
                PriceFullDay = 395,
                Seats = seatsHierGinder.ToList()
            };

            var seatsExecutiveRoom = new Seat[8];
            for (int i = 0; i < seatsExecutiveRoom.Length; i++)
            {
                seatsExecutiveRoom[i] = new Seat();
            }
            var TheExecutiveRoom = new MeetingRoom()
            {
                Name = "The Executive Room",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Seats = seatsExecutiveRoom.ToList()
            };

            var seatsBoardroom = new Seat[14];
            for (int i = 0; i < seatsBoardroom.Length; i++)
            {
                seatsBoardroom[i] = new Seat();
            }
            var Boardroom = new MeetingRoom()
            {
                Name = "Boardroom",
                PriceHalfDay = 225,
                PriceEvening = 295,
                PriceFullDay = 355,
                Seats = seatsBoardroom.ToList()
            };

            var seatsThePractice = new Seat[50];
            for (int i = 0; i < seatsThePractice.Length; i++)
            {
                seatsThePractice[i] = new Seat();
            }
            var ThePractice = new MeetingRoom()
            {
                Name = "The Practice",
                PriceHalfDay = 325,
                PriceEvening = 375,
                PriceFullDay = 455,
                Seats = seatsThePractice.ToList()
            };

            var seatsTheCourse = new Seat[120];
            for (int i = 0; i < seatsTheCourse.Length; i++)
            {
                seatsTheCourse[i] = new Seat();
            }
            var TheCourse = new MeetingRoom()
            {
                Name = "The Course",
                PriceHalfDay = 375,
                PriceEvening = 400,
                PriceFullDay = 550,
                Seats = seatsTheCourse.ToList()
            };

            List<MeetingRoom> meetingRoomsHier = new List<MeetingRoom>();
            meetingRoomsHier.Add(HierBoven);
            meetingRoomsHier.Add(HierGinder);
            meetingRoomsHier.Add(HierVanvoor);

            List<MeetingRoom> meetingRoomsKluizen = new List<MeetingRoom>();
            meetingRoomsKluizen.Add(TheExecutiveRoom);
            meetingRoomsKluizen.Add(Boardroom);
            meetingRoomsKluizen.Add(ThePractice);
            meetingRoomsKluizen.Add(TheCourse);

            #endregion

            #region Locations
            var locationGent = new Location()
            {
                Name = "HIER",
                Street = "Hier ergens",
                Number = 1,
                PostalCode = "BE9000",
                Place = "Gent",
                MeetingRooms = meetingRoomsHier,
                CoWorkRooms = coworkRoomsHier
            };
            var locationAalst = new Location()
            {
                Name = "Kluizen",
                Street = "Ergens anders",
                Number = 1,
                PostalCode = "BE9300",
                Place = "Aalst",
                MeetingRooms = meetingRoomsKluizen,
                CoWorkRooms = coworkRoomsKluizen
            };
            #endregion

            #region SaveAllTheThings!
            context.Locations.Add(locationGent);
            context.Locations.Add(locationAalst);

            context.SaveChanges();
            #endregion
        }
    }
}
