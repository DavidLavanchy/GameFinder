using GameFinder.Data;
using GameFinder.Models.GameModels;
using GameFinder.Models.GameSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameServices
    {
       
        public IEnumerable<GameListItem> GetGameByRating(string rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => e.Rating == rating)
                    .Select(
                        e =>
                        new GameListItem
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Description = e.Description,
                            Rating = e.Rating,
                            GameSystems = e.GameSystems,
                            Genres = e.Genres,
                            Price = e.Price,
                            MultiPlayer = e.MultiPlayer,
                        });
                return query.ToArray();
            }
        }































































































































































































        public bool AddGameToRepo(GameCreate model)
        {
            var entity =
                new Game()
                {
                    Description = model.Description,
                    GameSystems = model.GameSystems,
                    Genres = model.Genres,
                    Id = model.GameId,
                    MultiPlayer = model.MultiPlayer,
                    Price = model.Price,
                    Rating = model.Rating,
                    Title = model.Title
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
