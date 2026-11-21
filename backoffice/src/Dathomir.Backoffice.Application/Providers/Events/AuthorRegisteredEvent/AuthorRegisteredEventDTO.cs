using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Providers.Events.AuthorRegisteredEvent;

public record AuthorRegisteredEventDTO(Author author)
{
    public Guid Id { get; private set; } = author.Id;
    public string Name { get; private set; } = author.Name;
    public DateOnly DateOfBirth { get; private set; } = author.DateOfBirth;
    public DateOnly? DateOfDeath { get; private set; } = author.DateOfDeath;
}
