namespace Dathomir.Backoffice.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }

    Task BeginTransaction();
    Task Commit();
    Task SaveChanges(CancellationToken cancellationToken);
}
