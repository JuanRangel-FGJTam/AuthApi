using FluentValidation;
using AuthApi.Models;

namespace AuthApi.Validators.Preregistration;

public class ValidateRegistrationValidator : AbstractValidator<ValidateRegisterRequest>
{
    public ValidateRegistrationValidator(){
        RuleFor(model => model.Rfc)
            .MinimumLength(10)
            .MaximumLength(20)
            .WithName("RFC");

        RuleFor(model => model.Curp)
            .NotNull()
            .MinimumLength(10)
            .MaximumLength(20)
            .WithName("CURP");

        RuleFor(model => model.Name)
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Nombre");

        RuleFor(model => model.FirstName)
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Apellido Paterno");

        RuleFor(model => model.LastName)
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Apellido Materno");

        RuleFor(model => model.Birthdate)
            .NotNull()
            .LessThan(DateTime.Now.AddYears(-15))
            .WithName("Fecha de nacimiento");
        
        RuleFor(model => model.GenderId)
            .NotNull()
            .GreaterThan(0)
            .WithName("Género");

        RuleFor(model => model.MaritalStatusId)
            .GreaterThan(0)
            .WithName("Estado Civil");

        RuleFor(model => model.NationalityId)
            .GreaterThan(0)
            .WithName("Nacionalidad");

        RuleFor(model => model.OccupationId)
            .GreaterThan(0)
            .WithName("Ocupacion");

        RuleFor(model => model.AppName)
            .MaximumLength(120);

        RuleFor(model => model.Token)
            .NotEmpty()
            .WithName("Token Preregistro");
        
    }
}