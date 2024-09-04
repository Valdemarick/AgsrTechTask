using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Extensions.Patients;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Features.Patients.Commands.Create;

internal sealed class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand, PatientCreatedResponse>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientCreatedResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = request.Request.FromDto();
        _patientRepository.Add(patient);

        await _patientRepository.SaveChangesAsync(cancellationToken);

        return new PatientCreatedResponse(patient.Id);
    }
}
