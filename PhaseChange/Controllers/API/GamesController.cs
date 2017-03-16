using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhaseChange.Models;
using PhaseChange.DTOs;
using AutoMapper;

namespace PhaseChange.Controllers.API
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<GameDTO> GetGames()
        {
            return _context.Games.ToList().Select(Mapper.Map<Game, GameDTO>);
        }


        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDTO>(game));
        }

        [HttpPost]
        public IHttpActionResult CreateGame(GameDTO gameDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDTO, Game>(gameDTO);
            _context.Games.Add(game);
            _context.SaveChanges();

            gameDTO.Id = game.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDTO gameDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                return NotFound();

            Mapper.Map(gameDTO, gameInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                return NotFound();

            _context.Games.Remove(gameInDb);
            _context.SaveChanges();

            return Ok();
        }



    }
}
