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


        public IEnumerable<GameListItem> GetGameByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Title == title);
                yield return new GameListItem
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    Rating = entity.Rating,
                    GameSystems = entity.GameSystems,
                    Genres = entity.Genres,
                    Price = entity.Price,
                    MultiPlayer = entity.MultiPlayer,
                };
            }
        }

        public bool DeleteGameById(int id)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => id == e.Id);

                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => id == e.Id);
                   return new GameDetail
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    Title = entity.Title,
                    GameSystems = entity.GameSystems,
                    Genres = entity.Genres,
                    MultiPlayer = entity.MultiPlayer,
                    Price = entity.Price,
                    Rating = entity.Rating
                };
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

        public IEnumerable<GameListItem> GetGamesWithinPriceRange(decimal minPrice, decimal maxprice)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => e.Price > minPrice && e.Price < maxprice)
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
                        }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateGame(GameEdit updatedGame)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => updatedGame.Id == e.Id);

                entity.Title = updatedGame.Title;
                entity.Rating = updatedGame.Rating;
                entity.Price = updatedGame.Price;
                entity.Description = updatedGame.Description;
                entity.Genres = updatedGame.Genres;
                entity.GameSystems = updatedGame.GameSystems;
                entity.MultiPlayer = updatedGame.MultiPlayer;
                return ctx.SaveChanges() == 1;
            }
        }



        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new GameListItem
                        {
                            Id = e.Id,
                            Description = e.Description,
                            GameSystems = e.GameSystems,
                            Genres = e.Genres,
                            MultiPlayer = e.MultiPlayer,
                            Price = e.Price,
                            Rating = e.Rating,
                            Title = e.Title
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGamesByGenre(List<Genre> genres)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => genres == e.Genres)
                    .Select(
                        e =>
                        new GameListItem
                        {
                            Description = e.Description,
                            GameSystems = e.GameSystems,
                            Genres = e.Genres,
                            MultiPlayer = e.MultiPlayer,
                            Price = e.Price,
                            Rating = e.Rating,
                            Title = e.Title,
                            Id = e.Id,
                        });
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGamesByGameSystem(List<GameSystem> gameSystems)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => gameSystems == e.GameSystems)
                    .Select(e =>
                    new GameListItem
                    {
                        Description = e.Description,
                        GameSystems = e.GameSystems,
                        Genres = e.Genres,
                        MultiPlayer = e.MultiPlayer,
                        Price = e.Price,
                        Rating = e.Rating,
                        Title = e.Title,
                        Id = e.Id,
                    });
                return query.ToArray();

            }
        }
    }
}

