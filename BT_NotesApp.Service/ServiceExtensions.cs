using System;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Repository.Contracts;
using BT_NotesApp.Repository.Operations;
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

