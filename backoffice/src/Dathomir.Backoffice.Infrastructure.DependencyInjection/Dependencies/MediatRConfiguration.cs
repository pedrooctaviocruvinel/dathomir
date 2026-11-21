using Microsoft.Extensions.DependencyInjection;

namespace Dathomir.Backoffice.Infrastructure.DependencyInjection.Dependencies;

internal static class MediatRConfiguration
{
    public static void AddMediatR(this IServiceCollection services) =>
        services.AddMediatR(mrsc => mrsc.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Dathomir.Backoffice.Application")));
}
