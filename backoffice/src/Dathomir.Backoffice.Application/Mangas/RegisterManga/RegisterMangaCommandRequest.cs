using Dathomir.Backoffice.CrossCutting;
using Dathomir.Backoffice.Domain.Entities;
using MediatR;

namespace Dathomir.Backoffice.Application.Mangas.RegisterManga;

public class RegisterMangaCommandRequest : IRequest<Notification<RegisterMangaCommandResult>>
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }

    public Manga Map() =>
        new(Title, AuthorId);
}
