﻿// <auto-generated />
using System;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreHotelRoomBookingAdminPortal.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20190309043541_DemoD4")]
    partial class DemoD4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<double>("BookingPrice");

                    b.Property<int>("CustomerId");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.BookingDetail", b =>
                {
                    b.Property<int>("BookingId");

                    b.Property<int>("RoomId");

                    b.Property<int>("Quantity");

                    b.HasKey("BookingId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<long>("ContactNumber");

                    b.Property<string>("Country");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("District");

                    b.Property<string>("HotelAddress")
                        .IsRequired();

                    b.Property<int>("HotelContactNumber");

                    b.Property<string>("HotelDescription")
                        .IsRequired();

                    b.Property<string>("HotelEmailId")
                        .IsRequired();

                    b.Property<string>("HotelImage");

                    b.Property<string>("HotelName")
                        .IsRequired();

                    b.Property<string>("HotelRating")
                        .IsRequired();

                    b.Property<int>("HotelTypeId");

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<string>("RoomDescription")
                        .IsRequired();

                    b.Property<string>("RoomImage");

                    b.Property<int>("RoomPrice");

                    b.Property<string>("RoomType")
                        .IsRequired();

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelType", b =>
                {
                    b.Property<int>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelTypeDescription")
                        .IsRequired();

                    b.Property<string>("HotelTypeName")
                        .IsRequired();

                    b.HasKey("HotelTypeId");

                    b.ToTable("HotelTypes");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.roomFacility", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool>("Ekettle");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("Refrigerator");

                    b.Property<string>("RoomFacilityDescription");

                    b.Property<int>("RoomId");

                    b.Property<bool>("Wifi");

                    b.HasKey("RoomFacilityId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Booking", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.BookingDetail", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", "HotelRoom")
                        .WithMany("BookingDetails")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.HotelType", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.roomFacility", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", "HotelRoom")
                        .WithOne("roomFacility")
                        .HasForeignKey("CoreHotelRoomBookingAdminPortal.Models.roomFacility", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}