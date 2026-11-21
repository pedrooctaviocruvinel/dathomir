namespace Dathomir.Backoffice.Domain.Entities;

public class Author(string name, DateOnly dateOfBirth, DateOnly? dateOfDeath)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public DateOnly DateOfBirth { get; private set; } = dateOfBirth;
    public DateOnly? DateOfDeath { get; private set; } = dateOfDeath;
    public IList<Manga> Mangas { get; private set; } = [];
}
