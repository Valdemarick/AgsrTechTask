using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Dto.Requests;

internal sealed record CreatePatientRequest
{
    public CreatePatientNameRequest Name { get; init; } = null!;

    public DateTimeOffset BirthDate { get; init; }
    
    public Gender? Gender { get; init; }

    public bool Active { get; init; }
}

internal sealed record CreatePatientNameRequest
{
    public string Family { get; init; } = string.Empty;
    
    public string[] Given { get; init; } = Array.Empty<string>();

    public PatientNameFormality? Use { get; init; }
}