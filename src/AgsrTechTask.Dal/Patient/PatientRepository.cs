using AgsrTechTask.Domain.Patients;
using Microsoft.EntityFrameworkCore;

namespace AgsrTechTask.Dal.Patient;

internal sealed class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PatientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Domain.Patients.Patient>> GetListAsync(CancellationToken cancellationToken = default)
    {
        // TODO: date filtering
        return await _dbContext.Patients
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task<Domain.Patients.Patient?> GetByIdAsync(Guid id, bool withTracking = false, CancellationToken cancellationToken = default)
    {
        IQueryable<Domain.Patients.Patient> query = _dbContext.Patients;
        if (!withTracking)
        {
            query = query.AsNoTracking();
        }

        return query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Add(Domain.Patients.Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);
        _dbContext.Patients.Add(patient);
    }

    public void Update(Domain.Patients.Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);
        _dbContext.Patients.Update(patient);
    }

    public void Delete(Domain.Patients.Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);
        _dbContext.Patients.Remove(patient);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}