using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace BT_NotesApp.Logging;

public static class ServiceExtensions
{
    public static void ConfigureLogging(this IServiceCollection services)
    {
        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddDebug();
            logging.AddNLog("nlog.config");
        });
    }
}