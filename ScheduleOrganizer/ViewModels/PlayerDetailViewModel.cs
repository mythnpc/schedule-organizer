using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.ViewModels
{
    public class PlayerDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Availability { get; set; }
        public string DiscordName { get; set; }
        public Boolean CanCarry { get; set; }
        public ICollection<PlayerHeroViewModel> PlayerHeroes { get; set; }
    }
}
