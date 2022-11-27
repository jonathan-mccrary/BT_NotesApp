using System;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BT_NotesApp.Repository
{
	public static class ServiceExtensions
	{
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connString_SQLite = configuration.GetConnectionString("BoomTownDb_SQLite");
                var connString_SQLServer = configuration.GetConnectionString("BoomTownDb_SQLServer");
                var builder = new DbContextOptionsBuilder<NotesAppContext>();
                builder.UseSqlite(connString_SQLite);
                //builder.UseSqlServer(connString_SQLServer);
                return new NotesAppContext(builder.Options);
            });
        }
    }
}

