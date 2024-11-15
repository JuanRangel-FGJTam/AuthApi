using FluentValidation;
using AuthApi.Models;

namespace AuthApi.Validators.People;

public class NewPeopleValidator : AbstractValidator<PersonRequest>
{
    public NewPeopleValidator(){
        RuleFor(model => model.Rfc)
            .MinimumLength(10)
            .MaximumLength(20)
            .WithName("RFC");

        RuleFor(model => model.Curp)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(20)
            .WithName("CURP");

        RuleFor(model => model.Name)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Nombre");

        RuleFor(model => model.FirstName)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Apellido Paterno");

        RuleFor(model => model.LastName)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(120)
            .WithName("Apellido Materno");

        RuleFor(model => model.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(120)
            .WithName("Correo Electronico");

        RuleFor(model => model.Birthdate)
            .NotNull()
            .LessThan(DateTime.Now.AddYears(-15))
            .WithName("Fecha de nacimiento");
        
        RuleFor(model => model.GenderId)
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

    }
}