using Dathomir.Backoffice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dathomir.Backoffice.Infrastructure.DependencyInjection.Dependencies;

internal static class DataContextConfiguration
{
    public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDataContext>(dcob =>
            dcob.UseNpgsql(configuration.GetConnectionString("Postgresql"),
            ndcob => ndcob.MigrationsAssembly("Dathomir.Backoffice.Infrastructure.Data")));
    }
}
