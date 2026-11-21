using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dathomir.Backoffice.Infrastructure.Data.Repositories;

public class AuthorRepository(ApplicationDataContext applicationDataContext) : IAuthorRepository
{
    public IQueryable<Author> AsQueryable(string name) =>
        applicationDataContext.Authors
            .AsNoTracking()
            .Where(a =>
                (name == null || a.Name.Contains(name)));

    public async Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await applicationDataContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    public async Task<bool> Any(Guid id, CancellationToken cancellationToken) =>
        await applicationDataContext.Authors
            .AsNoTracking()
            .AnyAsync(a => a.Id == id, cancellationToken);

    public async Task AddAsync(Author author, CancellationToken cancellationToken) =>
        await applicationDataContext.Authors.AddAsync(author, cancellationToken);
}
