using FluentValidation;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Validations;

public class CartaValidator : AbstractValidator<Carta>
{
    public CartaValidator()
    {
        RuleFor(x => x.Nome).NotNull()
            .NotEmpty().MaximumLength(250);
        RuleFor(x => x.Tipo).NotNull().NotEmpty();
        RuleFor(x => x.Descricao).NotNull().NotEmpty();
        RuleFor(x => x.FotoUrl).NotNull().NotEmpty();
    }
}