namespace Dathomir.Backoffice.Application.Authors.ListAuthors;

public class ListAuthorsQueryResult(Guid id, string name)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
}
