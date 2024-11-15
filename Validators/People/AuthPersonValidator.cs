using FluentValidation;
using AuthApi.Models;

namespace AuthApi.Validators.People;

public class AuthPersonValidator: AbstractValidator<AuthenticateRequest>
{
    public AuthPersonValidator(){
        RuleFor(model => model.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(120)
            .WithName("Correo Electronico");

        RuleFor(model => model.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithName("Contraseña");

        RuleFor(model => model.IpAddress)
            .MinimumLength(4);

        RuleFor(model => model.UserAgent)
            .MinimumLength(4);
    }
}