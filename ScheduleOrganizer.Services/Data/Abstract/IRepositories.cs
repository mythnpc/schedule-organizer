using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Data.Abstract
{
    public interface IPlayerRepository : IEntityBaseRepository<Player> { }
    public interface ISeasonRepository : IEntityBaseRepository<Season> { }
    public interface IDungeonAttendanceRepository : IEntityBaseRepository<DungeonAttendance> { }

}
