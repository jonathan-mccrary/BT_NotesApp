using BT_NotesApp.Domain.Contracts.Repos;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Repository.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace BT_NotesApp.Service
{
    public static class ServiceExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<INotesRepo, NotesRepo>();
            services.AddTransient<INotesService, NotesService>();
        }
    }
}

