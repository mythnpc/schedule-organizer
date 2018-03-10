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
        public IHeroRepository _heroRepository;

        public PlayersController(IPlayerRepository playerRepository, IHeroRepository heroRepository)
        {
            _playerRepository = playerRepository;
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var players = _playerRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .AsQueryable()
                    .ProjectTo<PlayerViewModel>()
                    .ToList();

            return new OkObjectResult(players);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FindByName(int id)
        {
            var player = _playerRepository
                .AllIncluding(x => x.PlayerHero)
                .OrderBy(x => x.Id)
                .AsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefault();


            var playerHero = from p in player.PlayerHero
                             join ph in _heroRepository.GetAll() on p.HeroId equals ph.Id
                             select p;

            player.PlayerHero = playerHero.ToList();

            var test = Mapper.Map<PlayerDetailViewModel>(player);
            return new OkObjectResult(test);
        }
    }
}
