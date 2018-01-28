using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleOrganizer.Services.Models.Entities;

namespace ScheduleOrganizer.Services.Data
{
    public class ScheduleOrganizerContext : DbContext
    {
        public ScheduleOrganizerContext(DbContextOptions<ScheduleOrganizerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>()
                .ToTable("Schedule");

            modelBuilder.Entity<Season>()
                .Property(s => s.Start)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Season>()
                .Property(s => s.End)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Player>()
              .ToTable("Player");

            modelBuilder.Entity<Player>()
                .Property(u => u.CanCarry)
                .HasDefaultValue(false);

            modelBuilder.Entity<DungeonAttendance>()
              .ToTable("DungeonAttendance");

            modelBuilder.Entity<DungeonAttendance>()
                .HasOne(x => x.Player)
                .WithMany(y => y.DungeonAttendance)
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<DungeonAttendance>()
                .HasOne(x => x.Season)
                .WithMany(y => y.DungeonAttendance)
                .HasForeignKey(z => z.SeasonId);
        }
    }

}
