using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Models.Entities
{
    public class Season : IEntityBase
    {
        public Season()
        {
            DungeonAttendance = new List<DungeonAttendance>();
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ICollection<DungeonAttendance> DungeonAttendance { get; set; }

    }
}
