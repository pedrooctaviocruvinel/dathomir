using Dathomir.Backoffice.Application.Providers.Events.AuthorRegisteredEvent;
using Dathomir.Backoffice.Infrastructure.Provider.Kafka;
using Dathomir.Backoffice.Infrastructure.Provider.Kafka.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dathomir.Backoffice.Infrastructure.DependencyInjection.Dependencies;

internal static class EventConfiguration
{
    public static void AddEvents(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KafkaConfiguration>(configuration.GetSection("Kafka"));

        services.AddSingleton<IAuthorRegisteredEvent, AuthorRegisteredEvent>();
    }
}
