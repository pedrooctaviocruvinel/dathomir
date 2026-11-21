using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.CrossCutting;
using Dathomir.Backoffice.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.RegisterAuthor;

public class RegisterAuthorCommandHandler(IUnitOfWork unitOfWork, IValidator<Author> authorValidator) : IRequestHandler<RegisterAuthorCommandRequest, Notification<RegisterAuthorCommandResult>>
{
    public async Task<Notification<RegisterAuthorCommandResult>> Handle(RegisterAuthorCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        var author = commandRequest.Map();

        var authorValidationResult = authorValidator.Validate(author);

        if (!authorValidationResult.IsValid)
            return Notification<RegisterAuthorCommandResult>.CreateError(authorValidationResult.Errors);

        await unitOfWork.Authors.AddAsync(author, cancellationToken);
        await unitOfWork.SaveChanges(cancellationToken);

        return Notification<RegisterAuthorCommandResult>.CreateSuccess(new RegisterAuthorCommandResult(author));
    }
}
