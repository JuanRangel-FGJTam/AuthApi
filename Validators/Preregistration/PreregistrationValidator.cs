using FluentValidation;
using AuthApi.Models;

namespace AuthApi.Validators.Preregistration;

public class NewRegisterValidator : AbstractValidator<PreregistrationRequest>
{
    public NewRegisterValidator(){
        RuleFor(model => model.Mail)
            .NotNull()
            .EmailAddress()
            .MaximumLength(200)
            .WithName("Correo electronico");

        RuleFor(model => model.Password)
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(24)
            .WithName("Contraseña");

        RuleFor(model => model.ConfirmPassword)
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(24)
            .Equal( p => p.Password)
            .WithName("Confirmacion contraseña");
    }
}