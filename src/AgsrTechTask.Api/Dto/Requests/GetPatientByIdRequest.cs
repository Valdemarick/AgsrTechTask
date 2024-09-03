namespace AgsrTechTask.Api.Dto.Requests;

// public record GetPatientByIdRequest(Guid Id);

internal sealed record GetPatientByIdRequest
{
    public Guid Id { get; init; }
}