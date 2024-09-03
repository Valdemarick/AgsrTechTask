using AgsrTechTask.Api.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDependencies();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints(config => config.Endpoints.RoutePrefix = "api")
    .UseSwaggerGen();

app.Run();