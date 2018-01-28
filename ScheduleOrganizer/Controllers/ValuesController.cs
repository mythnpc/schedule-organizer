using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleOrganizer.Services.Data;
using ScheduleOrganizer.Services.Data.Abstract;
using AutoMapper.QueryableExtensions;
using ScheduleOrganizer.ViewModels;

namespace ScheduleOrganizer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IPlayerRepository _playerRepository;
        public ISeasonRepository _seasonRepository;
        public IDungeonAttendanceRepository _dungeonAttendanceRepository;

        public ValuesController(IPlayerRepository playerRepository, ISeasonRepository seasonRepository, IDungeonAttendanceRepository dungeonAttendanceRepository)
        {
            _playerRepository = playerRepository;
            _seasonRepository = seasonRepository;
            _dungeonAttendanceRepository = dungeonAttendanceRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var pagination = Request.Headers["Pagination"];

            var _players = _playerRepository
                    .AllIncluding(x => x.DungeonAttendance)
                    .OrderBy(x => x.Id)
                    .AsQueryable()
                    .ProjectTo<PlayerViewModel>()
                    .ToList();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
