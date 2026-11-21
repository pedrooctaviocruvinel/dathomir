using Dathomir.Backoffice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dathomir.Backoffice.Presentation.Helpers;

internal static class MigrationHelper
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();

        using ApplicationDataContext applicationDataContext = scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();

        if (applicationDataContext.Database.GetPendingMigrations().Any())
            applicationDataContext.Database.Migrate();
    }
}
