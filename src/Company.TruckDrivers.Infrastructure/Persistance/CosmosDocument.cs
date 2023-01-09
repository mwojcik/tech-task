using Company.TruckDrivers.Shared;
using Newtonsoft.Json;

namespace Company.TruckDrivers.Infrastructure.Persistance;

public class CosmosDocument<TDocument>
    where TDocument : class, IDocument
{
    public string Id { get; protected set; }
    
    [JsonProperty("PartitionKey")] 
    public string PartitionKey { get; protected set; }
    public string Type { get; protected set; }

    [JsonProperty("document")] 
    public TDocument Document { get; private set; }


    public CosmosDocument(TDocument document)
    {
        var documentIdentity = document.GetIdentity();
        Id = documentIdentity.DocumentId;
        PartitionKey = documentIdentity.PartitionKey;
        Type = typeof(TDocument).FullName;
        Document = document;
    }
}