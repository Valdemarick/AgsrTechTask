using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetById;

internal sealed class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, PatientResponse>
{
    public Task<PatientResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PatientResponse());
    }
}
