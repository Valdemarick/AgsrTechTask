using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Dto.Responses;

public record PatientResponse(
    PatientNameResponse Name,
    Gender Gender,
    DateTimeOffset BirthDate,
    bool Active);

public record PatientNameResponse(
    Guid Id,
    PatientNameFormality? Use,
    string Family,
    string[] Given);