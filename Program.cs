using GameGraphQLAPI.Context;
using GameGraphQLAPI.Controlers;
using GameGraphQLAPI.Interface;
using GameGraphQLAPI.Models;
using GameGraphQLAPI.Resolver;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GameGraphQLAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddDbContext<GamesDBContext>(options => options.UseMySql(ServerVersion.AutoDetect(connectionString)));

            // Add services to the container.

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();

            builder.Services.AddScoped<IResolver<Studio>, StudioResolver>();
            builder.Services.AddScoped<IResolver<Editor>, EditorResolver>();
            builder.Services.AddScoped<IResolver<Game>, GameResolver>();
            builder.Services.AddScoped<IFilter<Games>, GamesResolver>();

            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}