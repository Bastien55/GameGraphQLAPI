using GameGraphQLAPI.Context;
using GameGraphQLAPI.Controlers;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GameGraphQLAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<GamesDBContext>();

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();

            var app = builder.Build();

            app.MapGraphQL();

            app.UseAuthorization();

            app.Run();
        }
    }
}