using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Dto.Requests;

public sealed record UpdatePatientRequest
{
    public UpdatePatientNameRequest Name { get; init; } = null!;
    
    public DateTimeOffset BirthDate { get; init; }
    
    public Gender? Gender { get; init; }

    public bool Active { get; init; }
}

public sealed record UpdatePatientNameRequest
{
    public Guid Id { get; init; }
    
    public string Family { get; init; } = string.Empty;
    
    public string[] Given { get; init; } = Array.Empty<string>();

    public PatientNameFormality? Use { get; init; }
}