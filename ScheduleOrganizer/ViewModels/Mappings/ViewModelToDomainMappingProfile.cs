using AutoMapper;
using ScheduleOrganizer.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DungeonAttendanceViewModel, DungeonAttendance>();
        }
    }
}
