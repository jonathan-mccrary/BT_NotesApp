using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BT_NotesApp.Repository.Context
{
	public class NotesAppContextFactory : IDesignTimeDbContextFactory<NotesAppContext>
    {
        public NotesAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<NotesAppContext>();
            var connectionString = configuration.GetConnectionString("BoomTownDb");
            builder.UseSqlServer(connectionString);

            return new NotesAppContext(builder.Options);
        }
    }
}

