using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace AgsrTechTask.Api.Extensions;

internal static class DependencyInjection
{
    internal static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return AddFastEndpoints(services)
            .AddMediatr()
            .AddFluentValidation();
    }
    
    private static IServiceCollection AddFastEndpoints(IServiceCollection services)
    {
        return services.AddFastEndpoints()
            .SwaggerDocument();
    }

    private static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        return services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining(typeof(Program), includeInternalTypes: true);
    }
}