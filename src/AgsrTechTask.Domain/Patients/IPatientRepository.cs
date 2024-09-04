namespace AgsrTechTask.Domain.Patients;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetListAsync(CancellationToken cancellationToken = default);

    Task<Patient?> GetByIdAsync(Guid id, bool withTracking = false, CancellationToken cancellationToken = default);

    void Add(Patient patient);

    void Update(Patient patient);

    void Delete(Patient patient);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}