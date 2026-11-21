using Dathomir.Backoffice.Application.Repositories;

namespace Dathomir.Backoffice.Infrastructure.Data.Repositories;

public class AuthorRepository(ApplicationDataContext applicationDataContext) : IAuthorRepository { }
