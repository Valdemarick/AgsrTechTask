namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record GetPatientListRequest
{
    public string? BirthDate { get; init; }   
}