using GameFinder.Data;
using GameFinder.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GenreServices
    {
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre
                {
                    Description = model.Description,
                    GenreType = model.GenreType,
                    Id = model.Id,
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public GenreDetail GetGenreById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Genres
                    .Single(e => id == e.Id);
                return new GenreDetail
                {
                    Description = entity.Description,
                    GenreType = entity.GenreType,
                    Id = entity.Id
                };
            }
        }
        public IEnumerable<GenreListItem> GetAllGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Genres
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new GenreListItem
                        {
                            Description = e.Description,
                            GenreType = e.GenreType,
                            Id = e.Id,
                        });
                return query.ToArray();
            }
        }
        public bool UpdateGenre(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Genres
                    .Single(e => model.Id == e.Id);

                entity.Description = model.Description;
                entity.GenreType = model.GenreType;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Genres
                    .Single(e => id == e.Id);

                ctx.Genres.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
