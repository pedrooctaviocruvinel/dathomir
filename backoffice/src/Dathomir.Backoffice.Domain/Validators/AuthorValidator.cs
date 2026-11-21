using Dathomir.Backoffice.Domain.Entities;
using FluentValidation;

namespace Dathomir.Backoffice.Domain.Validators;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(a => a.Id)
            .NotEqual(Guid.Empty);

        RuleFor(a => a.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);
    }
}
