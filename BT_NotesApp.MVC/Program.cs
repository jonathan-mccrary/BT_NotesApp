using BT_NotesApp.Logging;
using BT_NotesApp.Repository;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Service;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages().AddMvcOptions(options =>
        {
            options.MaxModelValidationErrors = 50;
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required.");
        });

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        builder.Services.Configure<Program>(configuration);
        builder.Services.AddSingleton(provider => configuration);

        builder.Services.ConfigureLogging();
        builder.Services.ConfigureDependencies();
        builder.Services.ConfigureDbContext();

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<NotesAppContext>();
            db.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}