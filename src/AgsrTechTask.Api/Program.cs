using AgsrTechTask.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAllDependencies(builder.Configuration);

var app = builder.Build();

app.ConfigureHttpRequestPipeline();