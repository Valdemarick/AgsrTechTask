using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Commands.Update;

internal sealed class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
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
