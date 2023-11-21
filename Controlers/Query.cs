using GameGraphQLAPI.Context;
using GameGraphQLAPI.Interface;
using GameGraphQLAPI.Models;
using GameGraphQLAPI.Resolver;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Controlers
{
    /// <summary>
    /// Query for make some request
    /// </summary>
    [GraphQLDescription("Query will return the field in the request and the data of the database")]
    public class Query
    {
        /// <summary>
        /// All editors registered in the database
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the resolver Editor</param>
        /// <returns>A list of editors</returns>
        [GraphQLDescription("All editors registered in the database")]
        public List<Editor> GetEditors([Service] IResolver<Editor> resolver)
        {
            return resolver.GetAll().Result;
        }

        /// <summary>
        /// Only one editors registered in the database, filtered by the id
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the resolver Editor</param>
        /// <param name="id">The Editor ID we want to retrieve</param>
        /// <returns>An instance of editor</returns>
        [GraphQLDescription("Only one editors registered in the database, filtered by the id")]
        public Editor GetEditor([Service] IResolver<Editor> resolver, int id)
        {
            return resolver.GetByID(id).Result;
        }

        /// <summary>
        /// All studios registered in the database
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the resolver Studio</param>
        /// <returns>A list of studios</returns>
        [GraphQLDescription("All studios registered in the database")]
        public List<Studio> GetStudios([Service] IResolver<Studio> resolver) 
        {
            return resolver.GetAll().Result;
        }

        /// <summary>
        /// Only one studio registered in the database, filtered by the id
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the resolver Studio</param>
        /// <param name="id">The Studio ID we want to retrieve</param>
        /// <returns>An instance of studio</returns>
        [GraphQLDescription("Only one studio registered in the database, filtered by the id")]
        public Studio GetStudio([Service] IResolver<Studio> resolver, int id)
        {
            return resolver.GetByID(id).Result;
        }

        /// <summary>
        /// All game registered in the database
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the filter Games</param>
        /// <returns>A list of games filtered</returns>
        [GraphQLDescription("All game registered in the database")]
        public Games GetGames([Service] IFilter<Games> filter, FilterElement? filterElement = null)
        {
            return filter.GetListFiltered(filterElement);
        }

        /// <summary>
        /// Only one game registered in the database, filtered by the id
        /// </summary>
        /// <param name="resolver">From the service we get the instance that corresponded to the resolver Game</param>
        /// <param name="id">The Game ID we want to retrieve</param>
        /// <returns>An instance of game</returns>
        [GraphQLDescription("Only one game registered in the database, filtered by the id")]
        public Game GetGame([Service] IResolver<Game> resolver,int id)
        {
            return resolver.GetByID(id).Result;
        }
    }
}
