using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Authors.RegisterAuthor;

public class RegisterAuthorCommandResult(Author author)
{
    public Guid Id { get; private set; } = author.Id;
    public string Name { get; private set; } = author.Name;
}
