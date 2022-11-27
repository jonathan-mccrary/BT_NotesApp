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

            var connString_SQLite = configuration.GetConnectionString("BoomTownDb_SQLite");
            var connString_SQLServer = configuration.GetConnectionString("BoomTownDb_SQLServer");
            var builder = new DbContextOptionsBuilder<NotesAppContext>();
            builder.UseSqlite(connString_SQLite);
            //builder.UseSqlServer(connString_SQLServer);

            return new NotesAppContext(builder.Options);
        }
    }
}