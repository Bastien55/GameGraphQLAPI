using GameGraphQLAPI.Context;
using GameGraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Resolver
{
    public class GameResolver : IResolver<Game>
    {

        public GamesDBContext Context { get; set; }

        public GameResolver([Service] GamesDBContext context) 
        { 
            Context = context;
        }

        public async Task<List<Game>> GetAll()
        {
            return await Context
                         .Games
                         .Include(e => e.Editors)
                         .Include(s => s.Studios)
                         .ToListAsync();
        }

        public async Task<Game> GetByID(int id)
        {
            return await Context
                         .Games
                         .Include(e => e.Editors)
                         .Include(s => s.Studios)
                         .FirstOrDefaultAsync(element => element.GameId == id);
        }
    }
}
