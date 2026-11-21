using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Repositories;

public interface IAuthorRepository
{
    IQueryable<Author> AsQueryable(string name);
    Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Author author, CancellationToken cancellationToken);
}
