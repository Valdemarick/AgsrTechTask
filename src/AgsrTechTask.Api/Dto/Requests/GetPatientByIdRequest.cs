namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record GetPatientByIdRequest
{
    public Guid Id { get; init; }
}