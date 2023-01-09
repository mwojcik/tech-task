using Company.TruckDrivers.Application.Ports;
using Company.TruckDrivers.Shared;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace Company.TruckDrivers.Infrastructure.Persistance;

public class CosmoDatabaseContext : IDatabaseContext
{
    private readonly Container _cosmosContainer;
    
    public CosmoDatabaseContext(string databaseName, string containerName, string connectionString)
    {
        if (string.IsNullOrEmpty(databaseName)) throw new ArgumentNullException(nameof(databaseName));
        if (string.IsNullOrEmpty(containerName)) throw new ArgumentNullException(nameof(containerName));
        if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

        var cosmosClientBuilder = new CosmosClientBuilder(connectionString)
            .WithSerializerOptions(new CosmosSerializationOptions() {PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase})
            .WithConnectionModeDirect();
        

        var cosmosClient = cosmosClientBuilder.Build();
        _cosmosContainer = cosmosClient.GetContainer(databaseName, containerName);
    }
    
    
    public IQueryable<TDocument> Query<TDocument>() where TDocument : class, IDocument
    {
        return _cosmosContainer.GetItemLinqQueryable<CosmosDocument<TDocument>>()
            .Select(x=>x.Document);
    }
    
    public async Task AddAsync<TDocument>(TDocument document)
        where TDocument : class, IDocument
    {
        var cosmosDocument = new CosmosDocument<TDocument>(document);
        await _cosmosContainer.CreateItemAsync(cosmosDocument, new PartitionKey(document.GetIdentity().PartitionKey));
    }
}