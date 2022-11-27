using BT_NotesApp.Logging;
using BT_NotesApp.Repository;
using BT_NotesApp.Service;

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

        builder.Services.ConfigureDependencies();
        builder.Services.ConfigureLogging();
        builder.Services.ConfigureDbContext();

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