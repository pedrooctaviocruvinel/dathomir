using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Mangas.RegisterManga;

public class RegisterMangaCommandResult(Manga manga)
{
    public Guid Id { get; private set; } = manga.Id;
    public string Title { get; private set; } = manga.Title;
    public Guid AuthorId { get; private set; } = manga.AuthorId;
}
