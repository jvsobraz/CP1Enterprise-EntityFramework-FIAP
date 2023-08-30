using FluentValidation;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Validations;

public class LinksValidator : AbstractValidator<Links>
{
    public LinksValidator()
    {
        RuleFor(x => x.Links).NotNull()
            .NotEmpty().MaximumLength(250);
    }
}