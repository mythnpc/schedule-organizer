using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleOrganizer.Services.Data;
using ScheduleOrganizer.Services.Data.Abstract;
using ScheduleOrganizer.ViewModels;
using AutoMapper;
using ScheduleOrganizer.Services.Models.Entities;
using AutoMapper.QueryableExtensions;

namespace ScheduleOrganizer.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController: Controller
    {
        public IPlayerRepository _playerRepository;
        public ISeasonRepository _seasonRepository;
        public IDungeonAttendanceRepository _dungeonAttendanceRepository;

        public PlayersController(IPlayerRepository playerRepository, ISeasonRepository seasonRepository, IDungeonAttendanceRepository dungeonAttendanceRepository)
        {
            _playerRepository = playerRepository;
            _seasonRepository = seasonRepository;
            _dungeonAttendanceRepository = dungeonAttendanceRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _players = _playerRepository
                    .AllIncluding(x => x.DungeonAttendance)
                    .OrderBy(x => x.Id)
                    .AsQueryable()
                    .ProjectTo<PlayerViewModel>()
                    .ToList();

            return new OkObjectResult(_players);
        }
    }
}
