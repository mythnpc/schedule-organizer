using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Models.Entities
{
    public class Player: IEntityBase
    {
        public Player()
        {
            DungeonAttendance = new List<DungeonAttendance>();
            PlayerHero = new List<PlayerHero>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Availability { get; set; }
        public string Role { get; set; }
        public string DiscordName { get; set; }
        public Boolean CanCarry { get; set; }
        public ICollection<DungeonAttendance> DungeonAttendance { get; set; }
        public ICollection<PlayerHero> PlayerHero { get; set; }
    }
}
