using Dathomir.Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dathomir.Backoffice.Infrastructure.Data.Schemas;

internal static class MangaSchema
{
    public static void ConfigureMangaSchema(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Manga>(etb =>
        {
            etb.ToTable("mangas");

            etb.HasKey(m => m.Id);

            etb.Property(m => m.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            etb.Property(m => m.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            etb.Property(m => m.AuthorId)
                .HasColumnName("author_id")
                .HasColumnType("uuid")
                .IsRequired();

            etb.HasOne(m => m.Author)
                .WithMany(a => a.Mangas)
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        });
}
