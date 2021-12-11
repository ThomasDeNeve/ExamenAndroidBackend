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
            if (context.MeetingRooms.Any() && context.Locations.Any())
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
            /*var seatsHierVanvoor = new Seat[8];
            for(int i = 0; i < seatsHierVanvoor.Length; i++)
            {
                seatsHierVanvoor[i] = new Seat();
            }*/
            var HierVanvoor = new MeetingRoom()
            {
                Name = "HIER.Vanvoor",
                NumberOfSeats = 8,
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Description = "De gezelligste van onze vergaderzalen vind je vanvoor in het gebouw van HIER. Door de originele elementen in deze zaal, krijg je instant inspiratie. Deze zaal bied je een oplossing voor het delen van je interessante weetjes en in kleiner comité van maximum 7 personen. Deze zaal heeft een digi-scherm (verstelbaar van hoogte) en een elektrische zit-sta tafel. Leuk om een staande informele meeting te houden."
                //Seats = seatsHierVanvoor.ToList()
            };

            /*var seatsHierBoven = new Seat[14];
            for (int i = 0; i < seatsHierBoven.Length; i++)
            {
                seatsHierBoven[i] = new Seat();
            }*/
            var HierBoven = new MeetingRoom()
            {
                Name = "HIER.Boven",
                NumberOfSeats = 14,
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Description = "HIER.boven is overduidelijk onze mooiste, meest luxueuze zaal. Deze zaal kan 16 personen zetten. Tot de uitrusting behoren comfortabele zeteltjes, een grote mooie wig tafel met ingebouwde stekkers, internetaansluiting, projector, digitaal scherm, prima geluidsinstallatie en een goede belichting. De perfecte spot om te laten zien aan je beste klanten of een meeting te organiseren met je managementteam of directors of the board."
                //Seats = seatsHierBoven.ToList()
            };

            /*var seatsHierGinder = new Seat[40];
            for (int i = 0; i < seatsHierGinder.Length; i++)
            {
                seatsHierGinder[i] = new Seat();
            }*/
            var HierGinder = new MeetingRoom()
            {
                Name = "HIER.Ginder",
                NumberOfSeats = 40,
                PriceHalfDay = 275,
                PriceEvening = 325,
                PriceFullDay = 395,
                Description = "Onze zaal Ginder is de perfecte polyvalente opleidingszaal. Met de aanwezigheid van comfortabele stoelen, ruime tafels, het digischerm en goede belichting heeft dit creative lab alle fysieke elementen in huis om kwalitatief hoogstaande opleidingen of workshops aan te bieden.\n"
                               + "In onze zaal Ginder zijn verschillende opstellingen mogelijk: ronde, school, u - vorm, L - vorm, receptie …  De maximumcapaciteit bedraagt 40 personen, naargelang de opstelling van de zaal. Voor een zittende opleiding kun je comfortabel met 18 personen zitten."
                //Seats = seatsHierGinder.ToList()
            };

            /*var seatsExecutiveRoom = new Seat[8];
            for (int i = 0; i < seatsExecutiveRoom.Length; i++)
            {
                seatsExecutiveRoom[i] = new Seat();
            }*/
            var TheExecutiveRoom = new MeetingRoom()
            {
                Name = "The Executive Room",
                NumberOfSeats = 8,
                PriceHalfDay = 145,
                PriceTwoHours = 80,
                PriceEvening = 175,
                PriceFullDay = 250,
                Description = "In deze zaal staat een mooie grote marmeren tafel met plaats voor 8 mensen. Het grote raam zorgt voor veel lichtinval en samen met de inrichting van de zaal krijg je een gezellige en toch zakelijke sfeer. Deze zaal is perfect om met een board of directors samen te komen of je team te verwennen in deze setting. Wil je graag een formeel diner met wat privacy? Dat kan!"
                //Seats = seatsExecutiveRoom.ToList()
            };

            /*var seatsBoardroom = new Seat[14];
            for (int i = 0; i < seatsBoardroom.Length; i++)
            {
                seatsBoardroom[i] = new Seat();
            }*/
            var Boardroom = new MeetingRoom()
            {
                Name = "Boardroom",
                NumberOfSeats = 14,
                PriceHalfDay = 225,
                PriceEvening = 295,
                PriceFullDay = 355,
                Description = "Deze exclusieve, discrete zaal met Eames meubilair biedt plaats aan maximum 14 personen. Samenkomen met je team of management team is perfect in deze zaal. Deze ovalen tafel zorgt voor een leuke vergadersfeer. HIER. zijn al veel nieuwe ideeën geboren!"
                //Seats = seatsBoardroom.ToList()
            };

            /*var seatsThePractice = new Seat[50];
            for (int i = 0; i < seatsThePractice.Length; i++)
            {
                seatsThePractice[i] = new Seat();
            }*/
            var ThePractice = new MeetingRoom()
            {
                Name = "The Practice",
                NumberOfSeats = 50,
                PriceHalfDay = 325,
                PriceEvening = 375,
                PriceFullDay = 455,
                Description = "Zin om te vergaderen met panoramisch uitzicht op een groene omgeving?  Laat je inspiratie vrij in onze vergaderzaal The Practice. Deze polyvalente zaal is geschikt voor zowel vergaderingen,  workshops als presentaties t.e.m. 50 personen naargelang de opstelling met rustgevend zicht op het groen."
                //Seats = seatsThePractice.ToList()
            };

            /*var seatsTheCourse = new Seat[120];
            for (int i = 0; i < seatsTheCourse.Length; i++)
            {
                seatsTheCourse[i] = new Seat();
            }*/
            var TheCourse = new MeetingRoom()
            {
                Name = "The Course",
                NumberOfSeats = 120,
                PriceHalfDay = 375,
                PriceEvening = 400,
                PriceFullDay = 550,
                Description = "Onze grootste en meest polyvalente zaal met subliem uitzicht op het golfterrein, The Course! De perfecte locatie voor workshops, opleidingen, recepties… Geschikt tot maximum 140 personen naargelang de opstelling."
                //Seats = seatsTheCourse.ToList()
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

            #region Subscriptions
            /*HIER.af en toe € 70 5d per mnd
            HIER.haltijds € 120 10d per mnd
            HIER.voltijds * € 225 24 / 7 per mnd
            HIER.mijn vaste plek beneden* € 295 per mnd
            HIER.mijn vaste plek boven* € 320 per mnd
            HIER.voor een jaar € 195 10d per jaar*/

            //5 beurten of 1 maand
            Subscription AfEnToe = new Subscription() { Price = 70, Name = "HIER.af en toe", MaxNumberOfReservations = 5 };
            context.Subscriptions.Add(AfEnToe);

            //10 beurten of 1 maand
            Subscription Halftijds = new Subscription() { Price = 120, Name = "HIER.halftijds", MaxNumberOfReservations = 10 };
            context.Subscriptions.Add(Halftijds);

            //n beurten of 1 maand
            Subscription Voltijds = new Subscription() { Price = 225, Name = "HIER.voltijds" };
            context.Subscriptions.Add(Voltijds);

            //1 maand, vaste stoel beneden
            Subscription VastBeneden = new Subscription() { Price = 295, Name = "HIER.mijn vaste plek beneden" };
            context.Subscriptions.Add(VastBeneden);

            //1 maand, vaste stoel boven
            Subscription VastBoven = new Subscription() { Price = 320, Name = "HIER.mijn vaste plek boven" };
            context.Subscriptions.Add(VastBoven);

            //10 beurten of 1 jaar
            Subscription Jaar = new Subscription() { Price = 195, Name = "HIER.voor een jaar", MaxNumberOfReservations = 10 };
            context.Subscriptions.Add(Jaar);

            //context.SaveChanges();
            #endregion

            #region customerSubscriptionTest

            //Customer c = new Customer() {CustomerId = 12, Username = "test@test.com", Subscription = AfEnToe};
            //c.AddSubscription(AfEnToe);
            //context.Customers.Add(c);

            #endregion


            #region SaveAll

            context.Locations.Add(locationGent);
            context.Locations.Add(locationAalst);

            context.SaveChanges();
            #endregion
        }
    }
}
