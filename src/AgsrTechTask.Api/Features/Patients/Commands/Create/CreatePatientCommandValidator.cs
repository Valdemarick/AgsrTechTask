using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Commands.Create;

internal sealed class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.Request.Name)
            .NotNull();

        RuleFor(x => x.Request.Name.Family)
            .NotEmpty();

        RuleFor(x => x.Request.BirthDate)
            .NotEmpty();
    }
}
