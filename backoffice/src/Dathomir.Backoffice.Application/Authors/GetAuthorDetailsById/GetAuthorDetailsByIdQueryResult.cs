using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Authors.GetAuthorDetailsById;

public class GetAuthorDetailsByIdQueryResult(Author author)
{
    public Guid Id { get; private set; } = author.Id;
    public string Name { get; private set; } = author.Name;
    public DateOnly DateOfBirth { get; private set; } = author.DateOfBirth;
    public DateOnly? DateOfDeath { get; private set; } = author.DateOfDeath;
}
