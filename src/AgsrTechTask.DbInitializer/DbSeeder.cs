using AgsrTechTask.Dal;
using AgsrTechTask.Domain.Patients;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AgsrTechTask.DbInitializer;

internal sealed class DbSeeder
{
    private const int PatientAmount = 100;
    
    private readonly ApplicationDbContext _dbContext;
    
    public DbSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
    
    private void Migrate()
    {
        if (_dbContext.Database.GetPendingMigrations().Any())
        {
            _dbContext.Database.Migrate();
        }
    }

    private void SeedPatients()
    {
        _dbContext.AddRange(CreatePatientFaker().Generate(PatientAmount));
    }

    private Faker<Patient> CreatePatientFaker()
    {
        return new Faker<Patient>()
            .CustomInstantiator(f => new Patient(
                Guid.NewGuid(),
                f.Name.LastName(),
                f.Date.Past(80),
                f.Name.FirstName(),
                string.Empty,
                (PatientNameFormality)f.Random.Int(0, 1),
                (Gender)f.Random.Int(0, 3),
                f.Random.Bool()));
    }
}
