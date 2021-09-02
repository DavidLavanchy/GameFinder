using GameFinder.Data;
using GameFinder.Models.GameSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameSystemServices
    {
        public bool CreateGameSystem(GameSystemCreate gameSystem)
        {

            var entity =
                new GameSystem
                {
                    Id = gameSystem.Id,
                    SystemTitle = gameSystem.SystemTitle
            
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.GameSystems.Add(entity);
                return ctx.SaveChanges() == 1;        
            }
        }

        public IEnumerable<GameSystemListItem> GetAllGameSystems()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GameSystems
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new GameSystemListItem
                        {
                            Id = e.Id,
                            SystemTitle = e.SystemTitle,
                        });

                return query.ToArray();
            }
        }

        public bool UpdateGameSystem(GameSystemEdit updatedGameSystem)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameSystems
                    .Single(e => e.Id == updatedGameSystem.Id);

                entity.SystemTitle = updatedGameSystem.SystemTitle;

                return ctx.SaveChanges() == 1;
                
            }
        }

        public GameSystemDetail GetGameSystemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameSystems
                    .Single(e => id == e.Id);

                return new GameSystemDetail
                {
                    Id = entity.Id,
                    SystemTitle = entity.SystemTitle,
                };
            }
        }
        public bool DeleteGameSystemById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameSystems
                    .Single(e => id == e.Id);

                ctx.GameSystems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
