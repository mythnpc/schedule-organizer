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
using System;
using Microsoft.AspNetCore.Cors;

namespace ScheduleOrganizer.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class AttendanceController: Controller
    {
        public IPlayerRepository _playerRepository;
        public ISeasonRepository _seasonRepository;
        public IDungeonAttendanceRepository _dungeonAttendanceRepository;

        public AttendanceController(IPlayerRepository playerRepository, ISeasonRepository seasonRepository, IDungeonAttendanceRepository dungeonAttendanceRepository)
        {
            _playerRepository = playerRepository;
            _seasonRepository = seasonRepository;
            _dungeonAttendanceRepository = dungeonAttendanceRepository;
        }

        [HttpGet]
        public IActionResult Get(DateTime? From = null, DateTime? To = null)
        {
            var _attendance = _dungeonAttendanceRepository
                    .AllIncluding(x => x.Player, x => x.Season)
                    .AsQueryable()
                    .OrderBy(x => x.Id)
                    .Where(x => (From == null || DateTime.Compare(From.Value, x.Season.Start) <= 0) && (To == null || DateTime.Compare(To.Value, x.Season.End) >= 0))
                    .ProjectTo<DungeonAttendanceViewModel>()
                    .ToList();

            return new OkObjectResult(_attendance);
        }

        [HttpPost]
        public IActionResult CreateAttendance(DungeonAttendanceViewModel dungeonAttendanceViewModel)
        {
            DungeonAttendance _newAttendance = Mapper.Map<DungeonAttendanceViewModel, DungeonAttendance>(dungeonAttendanceViewModel);
            _dungeonAttendanceRepository.Add(_newAttendance);
            _dungeonAttendanceRepository.Commit();

            dungeonAttendanceViewModel = Mapper.Map<DungeonAttendance, DungeonAttendanceViewModel>(_newAttendance);

            CreatedAtRouteResult result = CreatedAtRoute("GetAttendance", new { controller = "Attendance", id = dungeonAttendanceViewModel.Id }, dungeonAttendanceViewModel);

            return result;
        }

        [HttpPut]
        public IActionResult UpdateAttendance([FromBody] DungeonAttendanceViewModel dungeonAttendanceViewModel)
        {
            var _attendanceDb = _dungeonAttendanceRepository.GetSingle(dungeonAttendanceViewModel.Id);

            if(_attendanceDb == null)
            {
                return NotFound();
            }
            else
            {
                _attendanceDb.FireDragonHardMode = dungeonAttendanceViewModel.FireDragonHardMode;
                _attendanceDb.IceDragonHardMode = dungeonAttendanceViewModel.IceDragonHardMode;
                _attendanceDb.PoisonDragonHardMode = dungeonAttendanceViewModel.PoisonDragonHardMode;
                _attendanceDb.BlackDragonHardMode = dungeonAttendanceViewModel.BlackDragonHardMode;

                _playerRepository.Commit();
            }

            dungeonAttendanceViewModel = Mapper.Map<DungeonAttendance, DungeonAttendanceViewModel>(_attendanceDb);

            return new OkObjectResult(dungeonAttendanceViewModel);
        }

        [HttpDelete]
        public IActionResult DeleteAttendance(DungeonAttendanceViewModel dungeonAttendanceViewModel)
        {
            var _attendanceDb = _dungeonAttendanceRepository.GetSingle(dungeonAttendanceViewModel.Id);

            if(_attendanceDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _dungeonAttendanceRepository.Delete(_attendanceDb);
                _dungeonAttendanceRepository.Commit();
            }

            return new NoContentResult();
        }

    }
}
