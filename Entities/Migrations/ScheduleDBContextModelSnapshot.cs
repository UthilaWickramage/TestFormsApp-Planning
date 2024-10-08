﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ScheduleDBContext))]
    partial class ScheduleDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HolidayId"));

                    b.Property<DateTime>("HolidayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HolidayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkStationId")
                        .HasColumnType("int");

                    b.HasKey("HolidayId");

                    b.HasIndex("WorkStationId");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<double>("DurationInHours")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VisibleEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VisibleStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("MachineId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.PendingOrder", b =>
                {
                    b.Property<int>("PendingOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PendingOrderId"));

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PendingOrderDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PendingOrderQty")
                        .HasColumnType("int");

                    b.Property<string>("PendingOrderTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PendingOrderId");

                    b.ToTable("PendingOrders");
                });

            modelBuilder.Entity("Entities.SpecialDay", b =>
                {
                    b.Property<int>("SpecialDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialDayId"));

                    b.Property<int>("SpecialDayCapacityPerHour")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDayDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SpecialDayEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SpecialDayStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkStationId")
                        .HasColumnType("int");

                    b.HasKey("SpecialDayId");

                    b.HasIndex("WorkStationId");

                    b.ToTable("SpecialDay");
                });

            modelBuilder.Entity("Entities.WorkStation", b =>
                {
                    b.Property<int>("WorkStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkStationId"));

                    b.Property<string>("CapacityPerHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkStationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkStationId");

                    b.ToTable("WorkStations");
                });

            modelBuilder.Entity("Entities.Holiday", b =>
                {
                    b.HasOne("Entities.WorkStation", "WorkStation")
                        .WithMany("Holidays")
                        .HasForeignKey("WorkStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkStation");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.HasOne("Entities.WorkStation", "Machine")
                        .WithMany("Orders")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Entities.SpecialDay", b =>
                {
                    b.HasOne("Entities.WorkStation", "WorkStation")
                        .WithMany("SpecialDays")
                        .HasForeignKey("WorkStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkStation");
                });

            modelBuilder.Entity("Entities.WorkStation", b =>
                {
                    b.Navigation("Holidays");

                    b.Navigation("Orders");

                    b.Navigation("SpecialDays");
                });
#pragma warning restore 612, 618
        }
    }
}
