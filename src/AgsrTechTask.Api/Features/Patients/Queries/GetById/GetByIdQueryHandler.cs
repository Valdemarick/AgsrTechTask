using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Exceptions;
using AgsrTechTask.Api.Extensions.Patients;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetById;

internal sealed class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, PatientResponse>
{
    private readonly IPatientRepository _patientRepository;

    public GetByIdQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdOrThrowAsync(request.Id);

        return patient.ToDto();
    }
}
