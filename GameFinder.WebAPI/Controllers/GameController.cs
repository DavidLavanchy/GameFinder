using GameFinder.Data;
using GameFinder.Models.GameModels;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameFinder.WebAPI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private GameServices CreateGameService()
        {
            var gameService = new GameServices();
            return gameService;
        }

        [HttpPost]
        public IHttpActionResult CreateGame(GameCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.AddGameToRepo(model))
                return InternalServerError();

            return Ok("Game successfully created");
        }

        [HttpGet]
        public IHttpActionResult GetGames()
        {
            var service = CreateGameService();

            var games = service.GetAllGames();
            return Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetGameById(int id)
        {
            var service = CreateGameService();

            var game = service.GetGameById(id);

            if (service.GetGameById(id) == null)
                return BadRequest("Id not found within database");

            return Ok(game);
        }

        [HttpGet]
        public IHttpActionResult GetPostsByRating(string rating)
        {
            var service = CreateGameService();

            var games = service.GetGameByRating(rating);

            if (service.GetGameByRating(rating) == null)
                return BadRequest("Rating not associated with any games within the database");

            return Ok(games);
        }
        [HttpGet]
        public IHttpActionResult GetGameByTitle(string title)
        {
            var service = CreateGameService();

            var game = service.GetGameByTitle(title);

            if (service.GetGameByTitle(title) == null)
                return BadRequest("Title does not exist within database");

            return Ok(game);
        }

        [HttpGet]
        public IHttpActionResult GetGamesWithinPriceRange(decimal minPrice, decimal maxPrice)
        {
            var service = CreateGameService();

            var games = service.GetGamesWithinPriceRange(minPrice, maxPrice);

            if (service.GetGamesWithinPriceRange(minPrice, maxPrice) == null)
                return BadRequest("No games in the database are within the desired price range");

            return Ok(games);
        }

        [HttpPut]
        public IHttpActionResult UpdateGame(GameEdit model)
        {
            var service = CreateGameService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.UpdateGame(model);

            return Ok("Game updated!");
        }

        [HttpGet]
        public IHttpActionResult GetGamesByGameSystem(List<GameSystem> gameSystems)
        {
            var service = CreateGameService();

            var games =service.GetGamesByGameSystem(gameSystems);

            if (service.GetGamesByGameSystem(gameSystems) == null)
                return BadRequest("No games correspond with the given gamesystem(s)");

            return Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetGamesByGenre(List<Genre> genres)
        {
            var service = CreateGameService();

            var games = service.GetGamesByGenre(genres);

            if (service.GetGamesByGenre(genres) == null)
                return BadRequest("No games fit within the given genre");

            return Ok(games);
        }

    }
}
