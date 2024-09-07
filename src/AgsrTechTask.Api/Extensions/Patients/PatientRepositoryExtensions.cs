using AgsrTechTask.Api.Exceptions;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Extensions.Patients;

internal static class PatientRepositoryExtensions
{
    internal static async Task<Patient> GetByIdOrThrowAsync(
        this IPatientRepository patientRepository,
        Guid id,
        bool withTracking = false)
    {
        var patient = await patientRepository.GetByIdAsync(id, withTracking: withTracking);
        if (patient is null)
        {
            throw new EntityNotFoundException(id);
        }

        return patient;
    }
}