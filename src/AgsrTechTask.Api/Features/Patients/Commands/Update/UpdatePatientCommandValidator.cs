using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Commands.Update;

internal sealed class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
    }
}
