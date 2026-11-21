using Dathomir.Backoffice.Domain.Entities;
using Dathomir.Backoffice.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Dathomir.Backoffice.Infrastructure.DependencyInjection.Dependencies;

internal static class FluentValidationConfiguration
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidator<Author>, AuthorValidator>();
        services.AddTransient<IValidator<Manga>, MangaValidator>();
    }
}
