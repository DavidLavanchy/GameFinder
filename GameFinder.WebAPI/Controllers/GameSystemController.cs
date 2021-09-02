using GameFinder.Models.GameSystemModels;
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
    public class GameSystemController : ApiController
    {
        private GameSystemServices CreateGameSystemService()
        {
            var service = new GameSystemServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateGameSystem(GameSystemCreate model)
        {
            var service = CreateGameSystemService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.CreateGameSystem(model))
                return InternalServerError();

            return Ok("GameSystem successfully created!");
        }

        [HttpGet]
        public IHttpActionResult GetGameSystemById(int id)
        {
            var service = CreateGameSystemService();

            var gameSystem = service.GetGameSystemById(id);

            if (service.GetGameSystemById(id) == null)
                return BadRequest("Game system with the provided id could not be found within the database");

            return Ok(gameSystem);
        }

        [HttpGet]
        public IHttpActionResult GetAllGameSystems()
        {
            var service = CreateGameSystemService();

            var gameSystems = service.GetAllGameSystems();

            return Ok(gameSystems);
        }

        [HttpPut]
        public IHttpActionResult UpdateGameSystems(GameSystemEdit model)
        {
            var service = CreateGameSystemService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.UpdateGameSystem(model);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGameSystem(int id)
        {
            var service = CreateGameSystemService();

            if (!service.DeleteGameSystemById(id))
                return BadRequest("Id not associated with a game syatem within database");

            return Ok();
        }
    }
}
