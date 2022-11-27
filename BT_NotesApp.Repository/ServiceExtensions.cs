using System;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Contracts;
using BT_NotesApp.Repository.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BT_NotesApp.Repository.Context
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

                var connectionString = configuration.GetConnectionString("BoomTownDb");
                var optionsBuilder = new DbContextOptionsBuilder<NotesAppContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new NotesAppContext(optionsBuilder.Options);
            });
        }
    }
}

