using EchoTrackV2.Data;
using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;
using EchoTrackV2.Services;
using Microsoft.EntityFrameworkCore;

namespace EchoTrackV2;

public class Program
{
    private static void PrepareDependencies(WebApplicationBuilder b)
    {
        b.Services.AddScoped<IAnimalRepository, SheepRepository>();
        b.Services.AddScoped<IAnimalRepository, HorseRepository>();
        b.Services.AddScoped<IAnimalService, HorseService>();
        b.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(b.Configuration.GetConnectionString("EchoTrackV2Context"));
        });
    }

    private static void PrepareServiceContainer(WebApplicationBuilder b)
    {
        b.Services.AddControllers();
        b.Services.AddSwaggerGen();
        PrepareDependencies(b);
    }

    private static void PrepapreHttpPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(/*opt => opt.SwaggerEndpoint("swagger/v1/swagger.json", "EchoTrack2 v1")*/);
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        PrepareServiceContainer(builder);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        PrepapreHttpPipeline(app);

        app.Run();
    }
}
