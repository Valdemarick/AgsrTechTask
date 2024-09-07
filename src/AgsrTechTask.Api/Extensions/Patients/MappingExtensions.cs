using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Extensions.Patients;

internal static class MappingExtensions
{
    public static PatientResponse ToDto(this Patient patient)
    {
        return new PatientResponse(
            new PatientNameResponse(
                patient.Id,
                patient.Name.Formality,
                patient.Name.LastName,
                new[] { patient.Name.FirstName, patient.Name.PatronymicName }),
            patient.Gender,
            patient.BirthDate,
            patient.IsActive);
    }

    public static Patient FromDto(this CreatePatientRequest request)
    {
        return new Patient(
            Guid.NewGuid(),
            request.Name.Family,
            request.BirthDate,
            request.Name.Given.FirstOrDefault(),
            request.Name.Given.LastOrDefault(),
            request.Name.Use,
            request.Gender,
            request.Active);
    }

    public static Patient FromDto(this UpdatePatientRequest request)
    {
        return new Patient(
            request.Name.Id,
            request.Name.Family,
            request.BirthDate,
            request.Name.Given.FirstOrDefault(),
            request.Name.Given.LastOrDefault(),
            request.Name.Use,
            request.Gender,
            request.Active);
    }

    public static PatientListResponse ToDtoList(this IEnumerable<Patient> patients)
    {
        return new PatientListResponse
        {
            Payload = patients.Select(ToDto),
        };
    }
}