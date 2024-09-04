namespace AgsrTechTask.Api.Dto.Responses;

public record PatientListResponse
{
    public IEnumerable<PatientResponse> Payload { get; init; }
}