﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ScheduleOrganizer.Services.Data;
using System;

namespace ScheduleOrganizer.Services.Migrations
{
    [DbContext(typeof(ScheduleOrganizerContext))]
    partial class ScheduleOrganizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleOrganizer.Services.Models.Entities.DungeonAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("SeasonId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.ToTable("DungeonAttendance");
                });

            modelBuilder.Entity("ScheduleOrganizer.Services.Models.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Availability");

                    b.Property<bool>("CanCarry")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("DiscordName");

                    b.Property<string>("Name");

                    b.Property<string>("Rank");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("ScheduleOrganizer.Services.Models.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 27, 12, 10, 57, 935, DateTimeKind.Local));

                    b.Property<DateTime>("Start")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 27, 12, 10, 57, 932, DateTimeKind.Local));

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("ScheduleOrganizer.Services.Models.Entities.DungeonAttendance", b =>
                {
                    b.HasOne("ScheduleOrganizer.Services.Models.Entities.Player", "Player")
                        .WithMany("DungeonAttended")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleOrganizer.Services.Models.Entities.Season", "Season")
                        .WithMany("DungeonAttendance")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
