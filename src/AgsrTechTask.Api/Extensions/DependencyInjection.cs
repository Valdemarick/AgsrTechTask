using AgsrTechTask.Api.Features.PipelineBehaviours;
using AgsrTechTask.Dal;
using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

namespace AgsrTechTask.Api.Extensions;

internal static class DependencyInjection
{
    public static IServiceCollection AddAllDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddApplication()
            .AddDal(configuration);
    }
    
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
        return services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>())
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining(typeof(Program), includeInternalTypes: true);
    }
}
