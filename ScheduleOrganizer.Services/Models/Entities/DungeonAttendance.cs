using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Models.Entities
{
    public class DungeonAttendance: IEntityBase
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
