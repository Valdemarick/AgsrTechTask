using AgsrTechTask.Dal;
using AgsrTechTask.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
    
var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.ConfigureServices(services =>
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("Database")));

    services.AddScoped<DbSeeder>();
});

var host = hostBuilder.Build();
using var scope = host.Services.CreateScope();
var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
try
{
    await dbSeeder.InitializeAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
