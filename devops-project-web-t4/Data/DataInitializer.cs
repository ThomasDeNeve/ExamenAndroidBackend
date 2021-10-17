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
            Price price = new SeatPrice()
            {
                Ocasionally = 70,
                Halftime = 120,
                Fulltime = 225,
                FixedDown = 295,
                FixedUp = 320,
                Year = 195
            };

            for (int i = 0; i < coworkSeatsHIER.Length; i++)
            {
                coworkSeatsHIER[i] = new Seat() { Price = price }; // Price als aparte entiteit? teveel duplicate data
            }
            var coworkSeatsKluizen = new Seat[20];
            for (int i = 0; i < coworkSeatsKluizen.Length; i++)
            {
                coworkSeatsKluizen[i] = new Seat() { Price = price }; // Price als aparte entiteit? teveel duplicate data
            }

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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 145,
                    TwoHours = 80,
                    Evening = 175,
                    FullDay = 250,
                },
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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 225,
                    Evening = 295,
                    FullDay = 355,
                },

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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 275,
                    Evening = 325,
                    FullDay = 395,
                },
                
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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 145,
                    TwoHours = 80,
                    Evening = 175,
                    FullDay = 250,
                },
                
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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 225,
                    Evening = 295,
                    FullDay = 355,
                },

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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 325,
                    Evening = 375,
                    FullDay = 455,
                },

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
                Price = new MeetingroomPrice()
                {
                    HalfDay = 375,
                    Evening = 400,
                    FullDay = 550,
                },

                Seats = seatsTheCourse.ToList()
            };

            var meetingroomsHIER = new MeetingRoom[]
            {
                HierBoven,
                HierGinder,
                HierVanvoor
            };
            var meetingroomsKluizen = new MeetingRoom[]
            {
                TheExecutiveRoom,
                Boardroom,
                ThePractice,
                TheCourse
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
                MeetingRooms = meetingroomsHIER.ToList(),
                CoWorkSeats = coworkSeatsHIER.ToList()
            };
            var locationAalst = new Location()
            {
                Name = "Kluizen",
                Street = "Ergens anders",
                Number = 1,
                PostalCode = "BE9300",
                Place = "Aalst",
                MeetingRooms = meetingroomsKluizen.ToList(),
                CoWorkSeats = coworkSeatsKluizen.ToList()
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
