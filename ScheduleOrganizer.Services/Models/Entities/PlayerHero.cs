using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Models.Entities
{
    public class PlayerHero : IEntityBase
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        public int TranscendentTier { get; set; }
        public int UniqueWeaponStars { get; set; }
    }
}
