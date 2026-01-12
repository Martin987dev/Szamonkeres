using Microsoft.EntityFrameworkCore;
using Szamonkeres.Models;
using System.Text.Json.Serialization;

namespace Szamonkeres
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers + JSON
            builder.Services
                .AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // DbContext
            builder.Services.AddDbContext<Models.CinemadbContext>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
