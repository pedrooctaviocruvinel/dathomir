using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.CrossCutting;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.RegisterAuthor;

public class RegisterAuthorCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RegisterAuthorCommandRequest, Notification<RegisterAuthorCommandResult>>
{
    public async Task<Notification<RegisterAuthorCommandResult>> Handle(RegisterAuthorCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        var author = commandRequest.Map();

        await unitOfWork.Authors.AddAsync(author, cancellationToken);
        await unitOfWork.SaveChanges(cancellationToken);

        return Notification<RegisterAuthorCommandResult>.CreateSuccess(new RegisterAuthorCommandResult(author));
    }
}
