using BT_NotesApp.Domain;
using BT_NotesApp.Logging;
using BT_NotesApp.Repository;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Service;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplication app = ConfigureBuilder(args);

        ConfigureApp(app);
    }

    private static WebApplication ConfigureBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        builder.Services.Configure<Program>(configuration);
        builder.Services.AddSingleton(provider => configuration);

        builder.Services.ConfigureLogging();
        builder.Services.ConfigureDependencies();
        builder.Services.ConfigureDbContext();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        return app;
    }

    private static void ConfigureApp(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<NotesAppContext>();
            var created = db.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.
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