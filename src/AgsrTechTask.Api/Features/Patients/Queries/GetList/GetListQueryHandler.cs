using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetList;

internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, PatientListResponse>
{
    public Task<PatientListResponse> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PatientListResponse());
    }
}
