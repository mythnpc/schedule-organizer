using AutoMapper;
using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Player, PlayerViewModel>();
            //.ForMember(
            //    vm => vm.DungeonAttendance, map => map.MapFrom(u => u.DungeonAttendance.Count()))
            //.DisableCtorValidation();

            CreateMap<DungeonAttendance, DungeonAttendanceViewModel>()
            .ForMember(vm => vm.PlayerName, map => map.MapFrom(u => u.Player.Name))
            .ForMember(vm => vm.DiscordName, map => map.MapFrom(u => u.Player.DiscordName))
            .ForMember(vm => vm.CanCarry, map => map.MapFrom(u => u.Player.CanCarry))
            .ForMember(vm => vm.Start, map => map.MapFrom(u => u.Season.Start))
            .ForMember(vm => vm.End, map => map.MapFrom(u => u.Season.End));

            CreateMap<Hero, HeroViewModel>();

            CreateMap<Player, PlayerDetailViewModel>()
            .ForMember(vm => vm.Id, map => map.MapFrom(u => u.Id))
            .ForMember(vm => vm.DiscordName, map => map.MapFrom(u => u.DiscordName))
            .ForMember(vm => vm.CanCarry, map => map.MapFrom(u => u.CanCarry))
            .ForMember(vm => vm.Availability, map => map.MapFrom(u => u.Availability))
            .ForMember(vm => vm.Name, map => map.MapFrom(u => u.Name))
            .ForMember(vm => vm.PlayerHeroes, map => map.MapFrom(u => u.PlayerHero));

            CreateMap<PlayerHero, PlayerHeroViewModel>()
                .ForMember(vm => vm.HeroId, map => map.MapFrom(u => u.HeroId))
                .ForMember(vm => vm.HeroName, map => map.MapFrom(u => u.Hero.Name))
                .ForMember(vm => vm.TranscendentTier, map => map.MapFrom(u => u.TranscendentTier))
                .ForMember(vm => vm.UniqueWeaponStars, map => map.MapFrom(u => u.UniqueWeaponStars));

        }
    }
}
