using AgsrTechTask.Dal.Extensions;
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
    
    public async Task<IEnumerable<Domain.Patients.Patient>> GetListAsync(
        string? dateFilter,
        CancellationToken cancellationToken = default)
    {
        var filter = dateFilter?.GetPatientListFilter();
        var query = _dbContext.Patients
            .AsNoTracking();
        query = GetFilteredQuery(query, filter!);

        return await query.ToListAsync(cancellationToken);
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

    private static IQueryable<Domain.Patients.Patient> GetFilteredQuery(
        IQueryable<Domain.Patients.Patient> query,
        PatientListFilter filter)
    {
        switch (filter.Operation)
        {
            case ComparisonOperation.None or ComparisonOperation.Ap or ComparisonOperation.Ge or ComparisonOperation.Le:
                return query;
            case ComparisonOperation.Equals:
            {
                var endDate = DateOnly.FromDateTime(filter.DateTime);
                var endOfTheDay = endDate.AddDays(1).ToDateTime(new TimeOnly()).AddMilliseconds(-1);

                return query.Where(x => x.BirthDate > filter.DateTime && x.BirthDate < endOfTheDay);
            }
            case ComparisonOperation.NotEquals:
            {
                var endDate = DateOnly.FromDateTime(filter.DateTime);
                var endOfTheDay = endDate.AddDays(1).ToDateTime(new TimeOnly()).AddMilliseconds(-1);
                
                return query.Where(x => x.BirthDate < filter.DateTime || x.BirthDate > endOfTheDay);
            }
            case ComparisonOperation.LessThan or ComparisonOperation.EndsBefore:
            {
                return query.Where(x => x.BirthDate < filter.DateTime);
            }
            case ComparisonOperation.GreaterThan or ComparisonOperation.StartsAfter:
            {
                return query.Where(x => x.BirthDate > filter.DateTime);
            }
        }
        
        return query;
    }
}