using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.Domain.Entities;

namespace Dathomir.Backoffice.Infrastructure.Data.Repositories;

public class MangaRepository(ApplicationDataContext applicationDataContext) : IMangaRepository
{
    public async Task AddAsync(Manga manga, CancellationToken cancellationToken) =>
        await applicationDataContext.Mangas.AddAsync(manga, cancellationToken);
}
