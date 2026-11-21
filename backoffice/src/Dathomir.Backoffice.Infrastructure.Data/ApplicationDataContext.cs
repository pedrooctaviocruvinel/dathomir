using Dathomir.Backoffice.Domain.Entities;
using Dathomir.Backoffice.Infrastructure.Data.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Dathomir.Backoffice.Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureAuthorSchema();

        base.OnModelCreating(modelBuilder);
    }
}
