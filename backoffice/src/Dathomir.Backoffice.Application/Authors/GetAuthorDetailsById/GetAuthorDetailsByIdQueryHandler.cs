using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.CrossCutting;
using Dathomir.Backoffice.CrossCutting.Enums;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.GetAuthorDetailsById;

public class GetAuthorDetailsByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAuthorDetailsByIdQueryRequest, Notification<GetAuthorDetailsByIdQueryResult>>
{
    public async Task<Notification<GetAuthorDetailsByIdQueryResult>> Handle(GetAuthorDetailsByIdQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.Authors.GetByIdAsync(queryRequest.Id, includeMangas: true, cancellationToken);

        if (author == null)
            return Notification<GetAuthorDetailsByIdQueryResult>.CreateError(ErrorCode.AuthorDoesntExists);

        return Notification<GetAuthorDetailsByIdQueryResult>.CreateSuccess(new GetAuthorDetailsByIdQueryResult(author));
    }
}
