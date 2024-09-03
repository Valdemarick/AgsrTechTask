namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record GetPatientListRequest
{
    public string DateFilter { get; init; }   
}