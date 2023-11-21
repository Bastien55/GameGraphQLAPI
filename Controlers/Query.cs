using GameGraphQLAPI.Context;
using GameGraphQLAPI.Interface;
using GameGraphQLAPI.Models;
using GameGraphQLAPI.Resolver;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Controlers
{
    public class Query
    {
        public List<Editor> GetEditors([Service] IResolver<Editor> resolver)
        {
            return resolver.GetAll().Result;
        }

        public Editor GetEditor([Service] IResolver<Editor> resolver, int id)
        {
            return resolver.GetByID(id).Result;
        }

        public List<Studio> GetStudios([Service] IResolver<Studio> resolver) 
        {
            return resolver.GetAll().Result;
        }

        public Studio GetStudio([Service] IResolver<Studio> resolver, int id)
        {
            return resolver.GetByID(id).Result;
        }

        public Games GetGames([Service] IFilter<Games> filter, FilterElement filterElement)
        {
            return filter.GetListFiltered(filterElement);
        }

        public Game GetGame([Service] IResolver<Game> resolver,int id)
        {
            return resolver.GetByID(id).Result;
        }
    }
}
