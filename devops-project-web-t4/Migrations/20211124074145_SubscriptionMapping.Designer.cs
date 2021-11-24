﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using devops_project_web_t4.Data;

namespace devops_project_web_t4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211124074145_SubscriptionMapping")]
    partial class SubscriptionMapping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

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
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Customer");
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

                    b.Property<int?>("LocationId")
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

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Reservation", b =>
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

                    b.Property<int?>("MeetingRoomId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MeetingRoomId");

                    b.HasIndex("SeatId", "From")
                        .IsUnique();

                    b.ToTable("Reservation");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkRoom", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Location", null)
                        .WithMany("CoWorkRooms")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.MeetingRoom", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Location", null)
                        .WithMany("MeetingRooms")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Reservation", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devops_project_web_t4.Areas.Domain.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingRoomId");

                    b.HasOne("devops_project_web_t4.Areas.Domain.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MeetingRoom");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Seat", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.CoworkRoom", null)
                        .WithMany("Seats")
                        .HasForeignKey("CoworkRoomId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Subscription", b =>
                {
                    b.HasOne("devops_project_web_t4.Areas.Domain.Customer", null)
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.CoworkRoom", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Customer", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("devops_project_web_t4.Areas.Domain.Location", b =>
                {
                    b.Navigation("CoWorkRooms");

                    b.Navigation("MeetingRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
