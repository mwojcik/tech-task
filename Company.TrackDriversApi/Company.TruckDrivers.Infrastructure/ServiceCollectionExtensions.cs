using Company.TruckDrivers.Application;
using Company.TruckDrivers.Application.Ports;
using Company.TruckDrivers.Infrastructure.Persistance;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.TruckDrivers.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureComponents(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);
        serviceCollection.AddScoped<IDocumentMapper, CosmoDocumentMapper>();
        serviceCollection.AddSingleton<IDatabaseContext>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var databaseName = configuration["CosmoDatabase:DatabaseName"];
            var containerName = configuration["CosmoDatabase:Container"];
            var connectionString = configuration["CosmoDatabase:ConnectionString"];

            return new CosmoDatabaseContext(databaseName, containerName, connectionString);
        });
    }
}