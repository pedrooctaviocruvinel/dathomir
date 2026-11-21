namespace Dathomir.Backoffice.Domain.Entities;

public class Author(string name)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
}
