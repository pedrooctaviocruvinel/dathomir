using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Authors.GetAuthorDetailsById;

public class GetAuthorDetailsByIdQueryResult(Author author)
{
    public Guid Id { get; private set; } = author.Id;
    public string Name { get; private set; } = author.Name;
    public DateOnly DateOfBirth { get; private set; } = author.DateOfBirth;
    public DateOnly? DateOfDeath { get; private set; } = author.DateOfDeath;
    public IList<GetAuthorDetailsByIdMangaQueryResult> Mangas { get; private set; } = GetAuthorDetailsByIdMangaQueryResult.Map(author.Mangas);
}

public class GetAuthorDetailsByIdMangaQueryResult(Manga manga)
{
    public Guid Id { get; private set; } = manga.Id;
    public string Title { get; private set; } = manga.Title;

    public static IList<GetAuthorDetailsByIdMangaQueryResult> Map(IList<Manga> mangas) =>
        [.. mangas.Select(m => new GetAuthorDetailsByIdMangaQueryResult(m))];
}
