using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleOrganizer.Services.Models.Entities
{
    public class Hero : IEntityBase
    {
        public Hero()
        {
            PlayerHero = new List<PlayerHero>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string UniqueWeapon { get; set; }
        public ICollection<PlayerHero> PlayerHero { get; set; }
    }
}
