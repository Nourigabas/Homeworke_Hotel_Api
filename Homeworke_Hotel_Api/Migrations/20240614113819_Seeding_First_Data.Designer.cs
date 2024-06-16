﻿// <auto-generated />
using System;
using Homeworke_Hotel_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Homeworke_Hotel_Api.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240614113819_Seeding_First_Data")]
    partial class Seeding_First_Data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckinAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckinAt = new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3288),
                            CheckoutAt = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            EmployeeId = 1,
                            GuestId = 1,
                            IsDeleted = false,
                            Price = 100m,
                            RoomId = 1
                        });
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOB = new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3194),
                            Email = "anything@gmail.com",
                            FirstName = "nouri",
                            HotelId = 1,
                            IsDeleted = false,
                            LastName = "gabas",
                            StartDate = new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "mager"
                        });
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOB = new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3264),
                            Email = "anything@gmail.com",
                            FirstName = "nouri",
                            IsDeleted = false,
                            LastName = "gabas",
                            Phone = "4477889966"
                        });
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "syria-idleb",
                            Email = "noury@aboalnour",
                            IsDeleted = false,
                            Name = "5 star",
                            Phone = "00352681609145"
                        });
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FloorNumber = 1,
                            HotelId = 1,
                            IsDeleted = false,
                            Number = 1,
                            RoomTypeId = 1,
                            Status = 1
                        });
                });

            modelBuilder.Entity("HotelDomin.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingId = 1,
                            CreatedDate = new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3324),
                            IsDeleted = false,
                            TotalAmount = 5m
                        });
                });

            modelBuilder.Entity("HotelDomin.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumOfBeds")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            NumOfBeds = 5,
                            TypeName = "anything"
                        });
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Booking", b =>
                {
                    b.HasOne("Homeworke_Hotel_Api.Models.Employee", "Employee")
                        .WithMany("Bookings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homeworke_Hotel_Api.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .IsRequired();

                    b.HasOne("Homeworke_Hotel_Api.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Employee", b =>
                {
                    b.HasOne("Homeworke_Hotel_Api.Models.Hotel", "Hotel")
                        .WithMany("Employees")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Room", b =>
                {
                    b.HasOne("Homeworke_Hotel_Api.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelDomin.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelDomin.Payment", b =>
                {
                    b.HasOne("Homeworke_Hotel_Api.Models.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Employee", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Guest", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Hotel", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Homeworke_Hotel_Api.Models.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelDomin.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
