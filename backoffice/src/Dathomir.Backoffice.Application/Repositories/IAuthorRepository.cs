using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Repositories;

public interface IAuthorRepository
{
    Task AddAsync(Author author, CancellationToken cancellationToken);
}
