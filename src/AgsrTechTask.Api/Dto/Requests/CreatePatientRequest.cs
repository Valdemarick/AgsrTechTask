namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record CreatePatientRequest
{
    public string Name { get; init; }
}