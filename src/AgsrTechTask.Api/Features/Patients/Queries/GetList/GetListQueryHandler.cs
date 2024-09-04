using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Extensions.Patients;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetList;

internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, PatientListResponse>
{
    private readonly IPatientRepository _patientRepository;

    public GetListQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public async Task<PatientListResponse> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetListAsync(cancellationToken);

        return patients.ToDtoList();
    }
}
