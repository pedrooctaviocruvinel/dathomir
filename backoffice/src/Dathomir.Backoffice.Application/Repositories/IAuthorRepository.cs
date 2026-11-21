using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Repositories;

public interface IAuthorRepository
{
    Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Author author, CancellationToken cancellationToken);
}
