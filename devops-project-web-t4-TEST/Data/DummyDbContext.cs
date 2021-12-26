using devops_project_web_t4.Areas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace devops_project_web_t4_TEST.Data
{
    public class DummyDbContext
    {
        public List<CoworkRoom> coworkRoomsKluizen;
        public List<CoworkRoom> coworkRoomsHier;

        public CoworkRoom bureel1;
        public CoworkRoom bureel2;
        public CoworkRoom coworking;

        public Seat[] coworkSeatsBureel1;
        public Seat[] coworkSeatsCoworking;
        public Seat[] coworkSeatsBureel2;

        public Seat[] seatsHierVanvoor;
        public Seat[] seatsHierBoven;
        public Seat[] seatsHierGinder;
        public Seat[] seatsExecutiveRoom;
        public Seat[] seatsBoardroom;
        public Seat[] seatsThePractice;
        public Seat[] seatsTheCourse;

        public List<MeetingRoom> meetingRooms;
        
        public MeetingRoom hierVanvoor;
        public MeetingRoom hierBoven;
        public MeetingRoom hierGinder;
        public MeetingRoom theExecutiveRoom;
        public MeetingRoom boardroom;
        public MeetingRoom thePractice;
        public MeetingRoom theCourse;

        public Location locationGent;
        public Location locationAalst;

        public Customer customer1;
        public Customer customer2;
        public Customer customer3;
        public Customer yves;

        public MeetingroomReservation meetingRoomReservation1;
        public MeetingroomReservation meetingRoomReservation2;

        public List<CustomerSubscription> customerSubscriptions;

        public DateTime dateTimeNow;


        public DummyDbContext()
        {
            #region rooms and stuff
            coworkRoomsKluizen = new List<CoworkRoom>();
            coworkRoomsHier = new List<CoworkRoom>();

            bureel1 = new CoworkRoom();
            coworking = new CoworkRoom();
            bureel2 = new CoworkRoom();

            coworkSeatsBureel1 = new Seat[4];

            customerSubscriptions = new List<CustomerSubscription>
            {
                new()
                {
                    Customer = customer1,
                    From = new DateTime(2022, 2, 1),
                    To = new DateTime(2022, 2, 28, 23, 59, 59),
                    Subscription = new()
                    {
                        MaxNumberOfReservations = 5,
                        Price = 50
                    }
                },

                new()
                {
                    Customer = customer1,
                    Subscription = new()
                    {
                        MaxNumberOfReservations = 10,
                        Price = 100
                    }
                }
            };

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

            coworkSeatsCoworking = new Seat[6];

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

            coworkSeatsBureel2 = new Seat[3];

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


            seatsHierVanvoor = new Seat[8];
            for (int i = 0; i < seatsHierVanvoor.Length; i++)
            {
                seatsHierVanvoor[i] = new Seat();
            }
            hierVanvoor = new MeetingRoom()
            {
                Name = "HIER.Vanvoor",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                //Seats = seatsHierVanvoor.ToList()
            };

            seatsHierBoven = new Seat[14];
            for (int i = 0; i < seatsHierBoven.Length; i++)
            {
                seatsHierBoven[i] = new Seat();
            }
            hierBoven = new MeetingRoom()
            {
                Name = "HIER.Boven",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                //Seats = seatsHierBoven.ToList()
            };

            seatsHierGinder = new Seat[40];
            for (int i = 0; i < seatsHierGinder.Length; i++)
            {
                seatsHierGinder[i] = new Seat();
            }
            hierGinder = new MeetingRoom()
            {
                Name = "HIER.Ginder",
                PriceHalfDay = 275,
                PriceEvening = 325,
                PriceFullDay = 395,
                //Seats = seatsHierGinder.ToList()
            };

            seatsExecutiveRoom = new Seat[8];
            for (int i = 0; i < seatsExecutiveRoom.Length; i++)
            {
                seatsExecutiveRoom[i] = new Seat();
            }
            theExecutiveRoom = new MeetingRoom()
            {
                Name = "The Executive Room",
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                //Seats = seatsExecutiveRoom.ToList()
            };

            seatsBoardroom = new Seat[14];
            for (int i = 0; i < seatsBoardroom.Length; i++)
            {
                seatsBoardroom[i] = new Seat();
            }
            boardroom = new MeetingRoom()
            {
                Name = "Boardroom",
                PriceHalfDay = 225,
                PriceEvening = 295,
                PriceFullDay = 355,
                //Seats = seatsBoardroom.ToList()
            };

            seatsThePractice = new Seat[50];
            for (int i = 0; i < seatsThePractice.Length; i++)
            {
                seatsThePractice[i] = new Seat();
            }
            thePractice = new MeetingRoom()
            {
                Name = "The Practice",
                PriceHalfDay = 325,
                PriceEvening = 375,
                PriceFullDay = 455,
                //Seats = seatsThePractice.ToList()
            };

            seatsTheCourse = new Seat[120];
            for (int i = 0; i < seatsTheCourse.Length; i++)
            {
                seatsTheCourse[i] = new Seat();
            }
            theCourse = new MeetingRoom()
            {
                Name = "The Course",
                PriceHalfDay = 375,
                PriceEvening = 400,
                PriceFullDay = 550,
                //Seats = seatsTheCourse.ToList()
            };

            List<MeetingRoom> meetingRoomsHier = new List<MeetingRoom>();
            meetingRoomsHier.Add(hierBoven);
            meetingRoomsHier.Add(hierGinder);
            meetingRoomsHier.Add(hierVanvoor);

            List<MeetingRoom> meetingRoomsKluizen = new List<MeetingRoom>();
            meetingRoomsKluizen.Add(theExecutiveRoom);
            meetingRoomsKluizen.Add(boardroom);
            meetingRoomsKluizen.Add(thePractice);
            meetingRoomsKluizen.Add(theCourse);

            locationGent = new Location()
            {
                Id = 1,
                Name = "HIER",
                Street = "Hier ergens",
                Number = 1,
                PostalCode = "BE9000",
                Place = "Gent",
                MeetingRooms = meetingRoomsHier,
                CoWorkRooms = coworkRoomsHier
            };

            locationAalst = new Location()
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
            #region customers
            customer1 = new Customer()
            {
                BTW = "123456",
                Email = "customer1@dummy.be",
                Firstname = "Peter",
                CustomerId = 1,
                Lastname = "Peters",
                Tel = "091234567",
                CustomerSubscriptions = customerSubscriptions
            };

            customer2 = new Customer()
            {
                BTW = "65468465",
                Email = "customer2@dummy.be",
                Firstname = "Roger",
                CustomerId = 2,
                Lastname = "Federer",
                Tel = "095468569"
            };

            customer3 = new Customer()
            {
                BTW = "9984654687",
                Email = "customer3@dummy.be",
                Firstname = "Koning",
                CustomerId = 3,
                Lastname = "Albert",
                Tel = "+3212345678"
            };

            yves = new Customer()
            {
                Email = "Yves.Vanduynslager@voestalpine.com",
                Firstname = "Yves",
                Lastname = "Vanduynslager",
                Tel = "666"
            };
            #endregion
            #region reservations
            meetingRoomReservation1 = new MeetingroomReservation()
            {
                Customer = customer1,
                From = new DateTime(2022, 2, 20, 8, 0, 0),
                To = new DateTime(2022, 2, 20, 12, 0, 0),
                Price = hierBoven.PriceHalfDay,
                IsConfirmed = true,
                MeetingRoom = hierBoven,
                MeetingroomId = 1
            };

            meetingRoomReservation2 = new MeetingroomReservation()
            {
                Customer = customer1,
                From = new DateTime(2022, 2, 20, 8, 0, 0),
                To = new DateTime(2022, 2, 20, 17, 0, 0),
                Price = hierBoven.PriceFullDay,
                IsConfirmed = true,
                MeetingRoom = hierBoven,
                MeetingroomId = 1
            };
            #endregion
            DateTime _now = DateTime.Now;
            dateTimeNow = new DateTime(_now.Year, _now.Month, _now.Day, 0, 0, 0);
        }
    }
}