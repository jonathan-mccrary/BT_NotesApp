using BT_NotesApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

internal class Program
{
    private static IConfiguration _configuration;
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        
        builder.Services.Configure<Program>(_configuration);
        builder.Services.AddSingleton(provider => _configuration);

        //var connection = _configuration.GetConnectionString("BoomTownDb");
        //builder.Services.AddDbContext<NotesAppContext>(options =>
        //    options.UseSqlServer(connection, b => b.MigrationsAssembly("BT_NotesApp.API"))
        //);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        

        var app = builder.Build();

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