using AgsrTechTask.Api.Extensions;
using AgsrTechTask.Dal;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddDal(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints(config => config.Endpoints.RoutePrefix = "api")
    .UseSwaggerGen();

app.Run();