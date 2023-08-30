using FluentValidation;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Validations;

public class RegrasEspeciaisValidator : AbstractValidator<RegrasEspeciais>
{
    public RegrasEspeciaisValidator()
    {
        RuleFor(x => x.Descricao).NotNull()
            .NotEmpty().MaximumLength(250);
        RuleFor(x => x.Data).NotNull().NotEmpty();
    }
}