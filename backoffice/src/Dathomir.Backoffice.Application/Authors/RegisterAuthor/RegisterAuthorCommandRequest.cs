using Dathomir.Backoffice.CrossCutting;
using Dathomir.Backoffice.Domain.Entities;
using MediatR;

namespace Dathomir.Backoffice.Application.Authors.RegisterAuthor;

public class RegisterAuthorCommandRequest : IRequest<Notification<RegisterAuthorCommandResult>>
{
    public string Name { get; set; }

    public Author Map() =>
        new(Name);
}
