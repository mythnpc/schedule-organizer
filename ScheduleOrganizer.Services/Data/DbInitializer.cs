using ScheduleOrganizer.Services.Models;
using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ScheduleOrganizerContext context)
        {
            context.Database.EnsureCreated();

            var players = new Player[]
            {
                new Player{Name="Jim", Availability="All the time", CanCarry= true, DiscordName="Jimboe", Rank="99", Role="Bauce" },
            };

            foreach (Player p in players)
            {
                context.Set<Player>().Add(p);
            }
            context.SaveChanges();
        }
    }
}
