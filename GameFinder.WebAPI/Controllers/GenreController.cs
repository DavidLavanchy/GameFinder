using GameFinder.Models.GenreModels;
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
    public class GenreController : ApiController
    {
        private GenreServices CreateGenreService()
        {
            var service = new GenreServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateGenre(GenreCreate model)
        {
            var service = CreateGenreService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.CreateGenre(model))
                return InternalServerError();

            return Ok("Genre successfully created");
        }
        [HttpGet]
        public IHttpActionResult GetGenre(int id)
        {
            var service = CreateGenreService();

            var genre = service.GetGenreById(id);

            if (service.GetGenreById(id) == null)
                return BadRequest("Id is invalid");

            return Ok(genre);
        }

        [HttpGet]
        public IHttpActionResult GetAllGenres()
        {
            var service = CreateGenreService();

            var genres = service.GetAllGenres();

            return Ok(genres);
        }

        [HttpPut]
        public IHttpActionResult UpdateGenre(GenreEdit model)
        {
            var service = CreateGenreService();

            if (!service.UpdateGenre(model))
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGenre(int id)
        {
            var service = CreateGenreService();

            if (!service.DeleteGenreById(id))
                return BadRequest();

            return Ok();
        }
    }
}
