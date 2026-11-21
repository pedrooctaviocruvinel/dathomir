namespace Dathomir.Backoffice.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }
    IMangaRepository Mangas { get; }

    Task BeginTransaction();
    Task Commit();
    Task SaveChanges(CancellationToken cancellationToken);
}
