using Dathomir.Backoffice.Infrastructure.DependencyInjection.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dathomir.Backoffice.Infrastructure.DependencyInjection;

public static class Bootstrapper
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDataContext(configuration);
}
