namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record DeletePatientRequest
{
    public Guid Id { get; init; }
}
