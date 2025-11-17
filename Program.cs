using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;
using EchoTrackV2.Services;

namespace EchoTrackV2;

public class Program
{
    private static void PrepareDependencies(WebApplicationBuilder b)
    {
        // b.Services.AddScoped<IAnimal, SheepRepository>();
    }

    private static void PrepareServiceContainer(WebApplicationBuilder b)
    {
        b.Services.AddControllers();
        b.Services.AddOpenApi();
        PrepareDependencies(b);
    }

    private static void PrepapreHttpPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1"));
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
