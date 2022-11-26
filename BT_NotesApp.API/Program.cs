using BT_NotesApp.DataAccess.Context;
using BT_NotesApp.DataAccess.Contracts;
using BT_NotesApp.DataAccess.Operations;
using BT_NotesApp.Domain.Contracts.Logic;
using BT_NotesApp.Domain.Logic;
using NLog.Web;


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
        builder.Services.AddTransient<NotesAppContext>();
        builder.Services.AddTransient<INotesDA, NotesDA>();
        builder.Services.AddTransient<INotesLogic, NotesLogic>();

        builder.Services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddDebug();
            logging.AddNLog("nlog.config");
        });

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