using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Commands.Create;

internal sealed class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
    }
}
