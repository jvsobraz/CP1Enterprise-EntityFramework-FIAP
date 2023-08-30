using FluentValidation;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Validations;

public class ColecaoValidator : AbstractValidator<Colecao>
{
    public ColecaoValidator()
    {
        RuleFor(x => x.Nome).NotNull()
            .NotEmpty().MaximumLength(250);
        RuleFor(x => x.Ano).NotNull().NotEmpty();
        RuleFor(x => x.LogoUrl).NotNull().NotEmpty();
    }
}