﻿// <auto-generated />
using devops_project_web_t4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace devops_project_web_t4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211204111819_MeetingroomReservation")]
    partial class MeetingroomReservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SeatId", "From")
                        .IsUnique();

                    b.ToTable("CoworkReservation");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("CoworkRoom");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BTW")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CustomerSubscription", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("DaysLeft")
                        .HasColumnType("double");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ReservationsLeft")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("LinkId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("CustomerSubscription");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.MeetingRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<double>("PriceEvening")
                        .HasColumnType("double");

                    b.Property<double>("PriceFullDay")
                        .HasColumnType("double");

                    b.Property<double>("PriceHalfDay")
                        .HasColumnType("double");

                    b.Property<double>("PriceTwoHours")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("MeetingRoom");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.MeetingroomReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MeetingroomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MeetingroomId", "From")
                        .IsUnique();

                    b.ToTable("MeetingroomReservation");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CoworkRoomId")
                        .HasColumnType("int");

                    b.Property<double>("PriceFixedDown")
                        .HasColumnType("double");

                    b.Property<double>("PriceFixedUp")
                        .HasColumnType("double");

                    b.Property<double>("PriceFulltime")
                        .HasColumnType("double");

                    b.Property<double>("PriceHalftime")
                        .HasColumnType("double");

                    b.Property<double>("PriceOcasionally")
                        .HasColumnType("double");

                    b.Property<double>("PriceYear")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CoworkRoomId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MaxNumberOfReservations")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkReservation", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devops_project_web_t4.Areas.Domain.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkRoom", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Location", null)
                        .WithMany("CoWorkRooms")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CustomerSubscription", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Customer", "Customer")
                        .WithMany("CustomerSubscriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devops_project_web_t4.Areas.Domain.Subscription", "Subscription")
                        .WithMany("CustomersSubscription")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.MeetingRoom", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Location", null)
                        .WithMany("MeetingRooms")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.MeetingroomReservation", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devops_project_web_t4.Areas.Domain.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MeetingRoom");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Seat", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.CoworkRoom", null)
                        .WithMany("Seats")
                        .HasForeignKey("CoworkRoomId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkRoom", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Customer", b =>
                {
                    b.Navigation("CustomerSubscriptions");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Location", b =>
                {
                    b.Navigation("CoWorkRooms");

                    b.Navigation("MeetingRooms");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Subscription", b =>
                {
                    b.Navigation("CustomersSubscription");
                });
#pragma warning restore 612, 618
        }
    }
}
