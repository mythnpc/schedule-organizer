using Microsoft.AspNetCore.Mvc;
using ScheduleOrganizer.Services.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleOrganizer.Controllers
{
    [Route("api/[controller]")]
    public class PlayerHeroesController : Controller
    {
        public IPlayerHeroRepository _playerHeroRepository;

        public PlayerHeroesController(IPlayerHeroRepository playerHeroRepository)
        {
            _playerHeroRepository = playerHeroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _heroes = _playerHeroRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .AsQueryable()
                    .ProjectTo<PlayerHeroViewModel>()
                    .ToList();

            return new OkObjectResult(_heroes);
        }
    }
}
