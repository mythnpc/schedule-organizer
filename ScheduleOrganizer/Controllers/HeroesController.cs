using Microsoft.AspNetCore.Mvc;
using ScheduleOrganizer.Services.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleOrganizer.Services.Models.Entities;
using ScheduleOrganizer.ViewModels;
using AutoMapper.QueryableExtensions;

namespace ScheduleOrganizer.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        public IHeroRepository _heroRepository;

        public HeroesController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _heroes = _heroRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .AsQueryable()
                    .ProjectTo<HeroViewModel>()
                    .ToList();

            return new OkObjectResult(_heroes);
        }
    }
}
