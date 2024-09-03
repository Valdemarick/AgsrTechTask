using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetList;

internal sealed record GetListQuery(GetPatientListRequest Request) : IQuery<PatientListResponse>;