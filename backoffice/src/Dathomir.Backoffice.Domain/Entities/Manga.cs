namespace Dathomir.Backoffice.Domain.Entities;

public class Manga(string title, Guid authorId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title;
    public Guid AuthorId { get; private set; } = authorId;
    public Author Author { get; private set; } = null;
}
