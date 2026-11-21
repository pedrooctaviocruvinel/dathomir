using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Infrastructure.Data.Repositories;

public class AuthorRepository(ApplicationDataContext applicationDataContext) : IAuthorRepository
{
    public async Task AddAsync(Author author, CancellationToken cancellationToken) =>
        await applicationDataContext.Authors.AddAsync(author, cancellationToken);
}
