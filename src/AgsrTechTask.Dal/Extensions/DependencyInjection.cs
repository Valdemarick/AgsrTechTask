using AgsrTechTask.Dal.Patient;
using AgsrTechTask.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgsrTechTask.Dal.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .InjectDependencies()
            .ConfigureDbContext(configuration);
    }

    private static IServiceCollection InjectDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IPatientRepository, PatientRepository>();
    }

    private static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetRequiredSection("ConnectionStrings:Database").Value;
        
        return services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
}