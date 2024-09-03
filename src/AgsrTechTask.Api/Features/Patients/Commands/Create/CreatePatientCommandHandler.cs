using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Commands.Create;

internal sealed class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand, PatientCreatedResponse>
{
    public Task<PatientCreatedResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PatientCreatedResponse());
    }
}
