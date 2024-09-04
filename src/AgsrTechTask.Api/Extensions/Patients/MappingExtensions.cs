using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Extensions.Patients;

internal static class MappingExtensions
{
    public static PatientResponse ToDto(this Patient patient)
    {
        return new PatientResponse();
    }

    public static Patient FromDto(this CreatePatientRequest request)
    {
        return default;
    }

    public static Patient FromDto(this UpdatePatientRequest request)
    {
        return default;
    }

    public static PatientListResponse ToDtoList(this IEnumerable<Patient> patients)
    {
        return new PatientListResponse
        {
            Payload = patients.Select(ToDto),
        };
    }
}