using AgsrTechTask.Dal;
using Microsoft.EntityFrameworkCore;

namespace AgsrTechTask.DbInitializer;

internal sealed class DbSeeder : IDisposable
{
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
    
    public void Initialize()
    {
        SeedPatients();
        _dbContext.SaveChanges();
    }

    private void SeedPatients()
    {
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
