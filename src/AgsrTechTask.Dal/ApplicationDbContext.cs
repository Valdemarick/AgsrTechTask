using Microsoft.EntityFrameworkCore;

namespace AgsrTechTask.Dal;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Patients.Patient> Patients => Set<Domain.Patients.Patient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IDalAssemblyMarker).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}