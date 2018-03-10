using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.ViewModels
{
    public class DungeonAttendanceViewModel
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string DiscordName { get; set; }
        public string CanCarry { get; set; }

        public int SeasonId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set;}

        public Boolean FireDragonHardMode { get; set; }
        public Boolean IceDragonHardMode { get; set; }
        public Boolean PoisonDragonHardMode { get; set; }
        public Boolean BlackDragonHardMode { get; set; }
    }
}
