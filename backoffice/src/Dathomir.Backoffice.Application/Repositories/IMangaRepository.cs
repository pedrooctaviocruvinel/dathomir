using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Application.Repositories;

public interface IMangaRepository
{
    Task AddAsync(Manga manga, CancellationToken cancellationToken);
}
