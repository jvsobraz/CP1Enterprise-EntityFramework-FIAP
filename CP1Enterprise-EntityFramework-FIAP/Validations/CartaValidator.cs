using FluentValidation;
using HookingHotels.Web.Entities;

namespace HookingHotels.Web.Validations;

public class HospedeValidator : AbstractValidator<Hospede>
{
    public HospedeValidator()
    {
        RuleFor(x => x.Nome).NotNull()
            .NotEmpty().MaximumLength(250);
        RuleFor(x => x.Telefone).NotNull().NotEmpty();
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
    }
}