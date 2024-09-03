using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetById;

internal sealed record GetByIdQuery(Guid Id) : IQuery<PatientResponse>;
