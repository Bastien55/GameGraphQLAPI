using GameGraphQLAPI.Context;
using GameGraphQLAPI.Interface;
using GameGraphQLAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Resolver
{
    public class GamesResolver : IFilter<Games>
    {
        public GamesDBContext Context { get; set; }
        public IFilter<Games> Filter { get; set; }

        public GamesResolver([Service] GamesDBContext context)
        {
            Context = context;
        }

        /// <summary>
        /// For each param verify if its null or not
        /// </summary>
        /// <returns></returns>
        public Games GetListFiltered(FilterElement filter)
        {
            var completedList = Context.Games.Include(e => e.Editors).Include(s => s.Studios).ToList();
            var listFiltered = completedList.Where(x => String.IsNullOrEmpty(filter.Genders) || x.Genres.Contains(filter.Genders));
            var listFilteredByPlatform = listFiltered.Where(x => String.IsNullOrEmpty(filter.Platforms) || x.Platform.Contains(filter.Platforms));
            var listFilteredByStudio = listFilteredByPlatform.Where(x => String.IsNullOrEmpty(filter.Studio) || x.Studios.Any(y => y.Name.Equals(filter.Studio))).ToList();

            Games games = new Games()
            {
                AllGame = listFilteredByStudio,
                Info = new Info()
                {
                    Pages = (int)Math.Ceiling(listFilteredByStudio.Count / 15F),
                    Count = listFilteredByStudio.Count,
                    Next = filter.Page + 1,
                    Previous = filter.Page == 0 ? 0 : filter.Page - 1,
                    
                }
            };

            return games;
        }
    }
}
