using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Commands.Delete;

internal sealed class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
