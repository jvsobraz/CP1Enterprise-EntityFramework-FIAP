using FluentValidation;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Validations;

public class IlustradorValidator : AbstractValidator<Ilustrador>
{
    public IlustradorValidator()
    {
        RuleFor(x => x.Nome).NotNull()
            .NotEmpty().MaximumLength(250);
    }
}