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
            CreateMap<Player, PlayerViewModel>()
            .ForMember(
                vm => vm.DungeonAttendance, map => map.MapFrom(u => u.DungeonAttendance.Count()))
            .DisableCtorValidation();
        }

    }
}
