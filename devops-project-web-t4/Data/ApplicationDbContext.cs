using devops_project_web_t4.Areas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace devops_project_web_t4.Data
{
    //Mysql update-database issue with Identity: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/865
    //Mysql Workbench: https://dev.mysql.com/downloads/mysql/
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations {get;set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CoworkRoom> CoworkRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Location>(MapLocation);

            builder.Entity<MeetingRoom>(MapMeetingRoom);
            builder.Entity<CoworkRoom>(MapCoworkRoom);

            builder.Entity<Seat>(MapSeat);

            builder.Entity<Customer>(MapCustomer);
            builder.Entity<Reservation>(MapReservation);
        }

        private static void MapLocation(EntityTypeBuilder<Location> location)
        {
            location.ToTable("Location");

            location.Property(l => l.Name).IsRequired();
            location.Property(l => l.Street).HasMaxLength(40).IsRequired();
            location.Property(l => l.Number).HasMaxLength(12).IsRequired(); //314a bus 111
            location.Property(l => l.PostalCode).HasMaxLength(10).IsRequired(); //BE-8000
            location.Property(l => l.Place).HasMaxLength(40).IsRequired();

            location.HasMany(l => l.MeetingRooms).WithOne();
            location.HasMany(l => l.CoWorkRooms).WithOne();
        }

        private static void MapMeetingRoom(EntityTypeBuilder<MeetingRoom> room)
        {
            room.ToTable("MeetingRoom");
            
            room.Property(r => r.Name).IsRequired();
            room.Property(r => r.NumberOfSeats).IsRequired();
            room.Property(r => r.PriceEvening).IsRequired();
            room.Property(r => r.PriceTwoHours);
            room.Property(r => r.PriceFullDay).IsRequired();
            room.Property(r => r.PriceHalfDay).IsRequired();
        }

        private static void MapCoworkRoom(EntityTypeBuilder<CoworkRoom> room)
        {
            room.ToTable("CoworkRoom");

            room.Property(r => r.Name).IsRequired();
            room.HasMany(r => r.Seats).WithOne();

        }

        private static void MapSeat(EntityTypeBuilder<Seat> seat)
        {
            seat.ToTable("Seat");
            seat.Property(p => p.PriceOcasionally).IsRequired();
            seat.Property(p => p.PriceFixedDown).IsRequired();
            seat.Property(p => p.PriceFixedUp).IsRequired();
            seat.Property(p => p.PriceFulltime).IsRequired();
            seat.Property(p => p.PriceHalftime).IsRequired();
            seat.Property(p => p.PriceYear).IsRequired();
        }

        private static void MapReservation(EntityTypeBuilder<Reservation> reservation)
        {
            reservation.ToTable("Reservation");

            reservation.Property(r => r.From).IsRequired();
            reservation.Property(r => r.To).IsRequired();
            reservation.Property(r => r.IsConfirmed).IsRequired();

            reservation.HasOne(r => r.Customer).WithMany()/*.HasForeignKey(r => r.CustomerId)*/.IsRequired();
            reservation.HasOne(r => r.MeetingRoom).WithMany()/*.HasForeignKey(r => r.MeetingRoomId)*/;
            reservation.HasOne(r => r.Seat).WithMany().HasForeignKey(r => r.SeatId);

            reservation.HasIndex(r => new { r.SeatId, r.From }).IsUnique();
        }

        private static void MapCustomer(EntityTypeBuilder<Customer> customer)
        {
            customer.ToTable("Customer");

            customer.Property(c => c.Firstname);
            customer.Property(c => c.Lastname);
            customer.Property(c => c.Username);
            customer.Property(c => c.Email);
            customer.Property(c => c.Tel);
            customer.Property(c => c.BTW);
        }
    }
}