using BT_NotesApp.Domain.Contracts.Logic;
using BT_NotesApp.Domain.Logic;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Contracts;
using BT_NotesApp.Repository.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace BT_NotesApp.Domain
{
    public static class ServiceExtensions
	{
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<NotesAppContext>();
            services.AddTransient<INotesRepo, NotesRepo>();
            services.AddTransient<INotesLogic, NotesLogic>();
        }
    }
}