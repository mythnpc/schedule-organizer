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
    public class PlayersController : Controller
    {
        public IPlayerRepository _playerRepository;
        public IHeroRepository _heroRepository;
        public IPlayerHeroRepository _playerHeroRepository;


        public PlayersController(IPlayerRepository playerRepository, IHeroRepository heroRepository, IPlayerHeroRepository playerHeroRepository)
        {
            _playerRepository = playerRepository;
            _heroRepository = heroRepository;
            _playerHeroRepository = playerHeroRepository;
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

        [HttpPost]
        [Route("{id}/heroes")]
        public IActionResult CreateHeroesByPlayerId(int playerId, [FromBody] PlayerHeroViewModel playerHeroViewModel)
        {
            var temp = new PlayerHero
            {
                PlayerId = playerId,
                HeroId = playerHeroViewModel.HeroId,
                TranscendentTier = playerHeroViewModel.TranscendentTier,
                UniqueWeaponStars = playerHeroViewModel.UniqueWeaponStars
            };

            _playerHeroRepository.Add(temp);
            _playerHeroRepository.Commit();

            CreatedAtRouteResult result = CreatedAtRoute("FindHeroesByPlayerId", new { controller = "Player", id = temp.Id }, temp);

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("{id}/heroes")]
        public IActionResult GetHeroesByPlayerId(int playerId)
        {
            var player = _playerRepository
                .AllIncluding(x => x.PlayerHero)
                .OrderBy(x => x.Id)
                .AsQueryable()
                .Where(x => x.Id == playerId)
                .FirstOrDefault();

            var playerHero = from p in player.PlayerHero
                             join ph in _heroRepository.GetAll() on p.HeroId equals ph.Id
                             select p;

            var playerHeroViewModels = playerHero.AsQueryable().ProjectTo<PlayerHeroViewModel>();
            return new OkObjectResult(playerHeroViewModels);
        }

        [HttpPut]
        [Route("{id}/heroes")]
        public IActionResult UpdateHeroesByPlayerId(int playerId, [FromBody]PlayerHeroViewModel playerHeroViewModel)
        {

            var _playerHero = _playerHeroRepository.GetSingle(x => x.HeroId == playerHeroViewModel.HeroId && x.PlayerId == playerId);
            _playerHero.TranscendentTier = playerHeroViewModel.TranscendentTier;
            _playerHero.UniqueWeaponStars = playerHeroViewModel.UniqueWeaponStars;
            _playerHeroRepository.Commit();
            return new OkObjectResult(_playerHero);
        }


        [HttpDelete]
        [Route("{id}/heroes")]
        public IActionResult DeleteHeroesByPlayerId(int playerId, PlayerHeroViewModel playerHeroViewModel)
        {

            var _playerHero = _playerHeroRepository.GetSingle(x => x.HeroId == playerHeroViewModel.HeroId && x.PlayerId == playerId);
            _playerHeroRepository.Delete(_playerHero);
            return new OkObjectResult(_playerHero.Id);
        }




    }
}
