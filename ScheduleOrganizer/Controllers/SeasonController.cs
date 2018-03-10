using Microsoft.AspNetCore.Mvc;
using ScheduleOrganizer.Services.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.Controllers
{
    [Route("api/[controller]")]
    public class SeasonController : Controller
    {
        public ISeasonRepository _seasonRepository;

        public SeasonController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var _seasons = _seasonRepository
                            .GetAll()
                            .OrderBy(x => x.Start);

            return new OkObjectResult(_seasons);
        }
    }
}
