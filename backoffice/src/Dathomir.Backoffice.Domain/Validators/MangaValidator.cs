using Dathomir.Backoffice.Domain.Entities;
using FluentValidation;

namespace Dathomir.Backoffice.Domain.Validators;

public class MangaValidator : AbstractValidator<Manga>
{
    public MangaValidator()
    {
        RuleFor(m => m.Id)
            .NotEqual(Guid.Empty);

        RuleFor(m => m.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(m => m.AuthorId)
            .NotEqual(Guid.Empty);
    }
}
