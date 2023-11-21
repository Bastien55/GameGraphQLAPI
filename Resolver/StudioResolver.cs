using GameGraphQLAPI.Context;
using GameGraphQLAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Resolver
{
    public class StudioResolver : IResolver<Studio>
    {

        public GamesDBContext Context { get; set; }

        public StudioResolver([Service] GamesDBContext context)
        {
            Context = context;
        }

        public async Task<List<Studio>> GetAll()
        {
            return await Context.Studios.ToListAsync();
        }

        public async Task<Studio> GetByID(int id)
        {
            return await Context.Studios.FindAsync(id);
        }
    }
}
