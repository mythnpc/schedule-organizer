using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleOrganizer.Services.Models.Entities;

namespace ScheduleOrganizer.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Availability { get; set; }
        public string DiscordName { get; set; }
        public Boolean CanCarry { get; set; }
        public int DungeonAttendance { get; set; }

    }
}
