using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.CrossCutting;
using Dathomir.Backoffice.CrossCutting.Enums;
using Dathomir.Backoffice.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Dathomir.Backoffice.Application.Mangas.RegisterManga;

public class RegisterMangaCommandHandler(IUnitOfWork unitOfWork, IValidator<Manga> mangaValidator) : IRequestHandler<RegisterMangaCommandRequest, Notification<RegisterMangaCommandResult>>
{
    public async Task<Notification<RegisterMangaCommandResult>> Handle(RegisterMangaCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        if (!await unitOfWork.Authors.Any(commandRequest.AuthorId, cancellationToken))
            return Notification<RegisterMangaCommandResult>.CreateError(ErrorCode.AuthorDoesntExists);

        var manga = commandRequest.Map();

        var mangaValitationResult = mangaValidator.Validate(manga);

        if (!mangaValitationResult.IsValid)
            return Notification<RegisterMangaCommandResult>.CreateError(mangaValitationResult.Errors);

        await unitOfWork.Mangas.AddAsync(manga, cancellationToken);
        await unitOfWork.SaveChanges(cancellationToken);

        return Notification<RegisterMangaCommandResult>.CreateSuccess(new RegisterMangaCommandResult(manga));
    }
}
