using Dathomir.Backoffice.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dathomir.Backoffice.Infrastructure.Data.Repositories;

public class UnitOfWork(ApplicationDataContext applicationDataContext) : IUnitOfWork
{
    public IAuthorRepository Authors { get; } = new AuthorRepository(applicationDataContext);

    private IDbContextTransaction _transaction;

    public async Task BeginTransaction() =>
        _transaction ??= await applicationDataContext.Database.BeginTransactionAsync();

    public async Task Commit()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }
    }

    public async Task SaveChanges(CancellationToken cancellationToken) =>
        await applicationDataContext.SaveChangesAsync(cancellationToken);

    public void Dispose() =>
        applicationDataContext.Dispose();
}
