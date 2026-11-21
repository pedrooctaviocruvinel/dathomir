using Dathomir.Backoffice.Application.Repositories;
using Dathomir.Backoffice.CrossCutting;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.ListAuthors;

public class ListAuthorsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<ListAuthorsQueryRequest, Notification<PaginationResult<ListAuthorsQueryResult>>>
{
    public async Task<Notification<PaginationResult<ListAuthorsQueryResult>>> Handle(ListAuthorsQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        var authorQuery = unitOfWork.Authors.AsQueryable(queryRequest.Name);

        var mappedAuthorQuery = authorQuery.Select(u => new ListAuthorsQueryResult(u.Id, u.Name));

        var pagedResult = PaginationResult<ListAuthorsQueryResult>.ToPagedResult(mappedAuthorQuery, queryRequest.PageSize, queryRequest.PageNumber);

        return Notification<PaginationResult<ListAuthorsQueryResult>>.CreateSuccess(pagedResult);
    }
}
