﻿using BT_NotesApp.DataAccess.Context;
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
        builder.Services.AddControllersWithViews();

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

        //var connection = _configuration.GetConnectionString("BoomTownDb");
        //builder.Services.AddDbContext<NotesAppContext>(options =>
        //    options.UseSqlServer(connection)
        //);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}