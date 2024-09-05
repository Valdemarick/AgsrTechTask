using AgsrTechTask.Dal;
using AgsrTechTask.Domain.Patients;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AgsrTechTask.DbInitializer;

internal sealed class DbSeeder : IDisposable
{
    private const int PatientAmount = 100;
    
    private readonly ApplicationDbContext _dbContext;
    
    public DbSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Migrate()
    {
        if (_dbContext.Database.GetPendingMigrations().Any())
        {
            _dbContext.Database.Migrate();
        }
    }
    
    public async Task InitializeAsync()
    {
        Migrate();
        if (!await _dbContext.Patients.AnyAsync())
        {
            SeedPatients();
        }

        await _dbContext.SaveChangesAsync();
    }

    private void SeedPatients()
    {
        _dbContext.AddRange(CreatePatientFaker().Generate(PatientAmount));
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    private Faker<Patient> CreatePatientFaker()
    {
        return new Faker<Patient>()
            .CustomInstantiator(f => new Patient(
                f.Name.LastName(),
                f.Date.Past(80),
                f.Name.FirstName(),
                string.Empty,
                (PatientNameFormality)f.Random.Int(0, 1),
                (Gender)f.Random.Int(0, 3),
                f.Random.Bool()));
    }
}
