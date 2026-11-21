using Dathomir.Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dathomir.Backoffice.Infrastructure.Data.Schemas;

internal static class AuthorSchema
{
    public static void ConfigureAuthorSchema(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(etb =>
        {
            etb.ToTable("authors");

            etb.HasKey(a => a.Id);

            etb.HasIndex(a => a.Id)
                .IsUnique();

            etb.Property(a => a.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            etb.Property(a => a.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            etb.Property(a => a.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date")
                .IsRequired();

            etb.Property(a => a.DateOfDeath)
                .HasColumnName("date_of_death")
                .HasColumnType("date");
        });
    }
}
