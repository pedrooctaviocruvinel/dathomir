using Dathomir.Backoffice.CrossCutting;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.ListAuthors;

public class ListAuthorsQueryRequest : PaginationRequest, IRequest<Notification<PaginationResult<ListAuthorsQueryResult>>>
{
    public string Name { get; set; }
}
