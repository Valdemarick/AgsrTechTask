using System.Text.Json.Serialization;
using AgsrTechTask.Api.Exceptions;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace AgsrTechTask.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleAsync(context, ex.Message, StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex.Message, StatusCodes.Status500InternalServerError);
            }
        });
        
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

    private static Task HandleAsync(
        HttpContext context,
        string message,
        int statusCode)
    {
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Detail = message,
        });
    }
}
