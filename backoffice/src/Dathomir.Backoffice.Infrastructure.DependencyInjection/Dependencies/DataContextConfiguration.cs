using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.Infrastructure.Data;
using Dathomir.Backoffice.Infrastructure.Data.Repositories;
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

        services.AddTransient<IAuthorRepository, AuthorRepository>();
        services.AddTransient<IMangaRepository, MangaRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
