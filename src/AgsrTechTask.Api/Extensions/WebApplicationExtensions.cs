using FastEndpoints;
using FastEndpoints.Swagger;

namespace AgsrTechTask.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseFastEndpoints(config => config.Endpoints.RoutePrefix = "api")
            .UseSwaggerGen();

        app.Run();

        return app;
    }
}
