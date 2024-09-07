using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace AgsrTechTask.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseFastEndpoints(config =>
            {
                config.Endpoints.RoutePrefix = "api";
                config.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
            })
            .UseSwaggerGen();

        app.Run();

        return app;
    }
}
