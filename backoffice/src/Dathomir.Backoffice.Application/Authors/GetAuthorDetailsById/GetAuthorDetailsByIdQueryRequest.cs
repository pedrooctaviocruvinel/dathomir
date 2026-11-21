using Dathomir.Backoffice.CrossCutting;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.GetAuthorDetailsById;

public class GetAuthorDetailsByIdQueryRequest : IRequest<Notification<GetAuthorDetailsByIdQueryResult>>
{
    public Guid Id { get; set; }
}
