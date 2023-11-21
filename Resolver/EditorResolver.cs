﻿using GameGraphQLAPI.Context;
using GameGraphQLAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Resolver
{
    /// <summary>
    /// Class for return the datas from the database by some methods 
    /// </summary>
    public class EditorResolver : IResolver<Editor>
    {

        public GamesDBContext Context { get; set; }

        public EditorResolver([Service] GamesDBContext context)
        {
            Context = context;
        }

        public async Task<List<Editor>> GetAll()
        {
            return await Context.Editors.ToListAsync();
        }

        public async Task<Editor> GetByID(int id)
        {
            return await Context.Editors.FindAsync(id);
        }
    }
}
