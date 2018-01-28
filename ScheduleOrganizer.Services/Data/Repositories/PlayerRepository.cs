using ScheduleOrganizer.Services.Data.Abstract;
using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Data.Repositories
{
    public class PlayerRepository : EntityBaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ScheduleOrganizerContext context)
            : base(context)
        { }
    }
}
