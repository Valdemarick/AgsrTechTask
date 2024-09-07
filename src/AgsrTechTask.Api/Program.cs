using AgsrTechTask.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAllDependencies(builder.Configuration);

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

app.ConfigureHttpRequestPipeline();