using Company.TruckDrivers.Application.Ports;
using Microsoft.Azure.Cosmos.Linq;

namespace Company.TruckDrivers.Infrastructure.Persistance;

public class CosmoDocumentMapper : IDocumentMapper
{
    public async Task<List<T>> ToDocumentListAsync<T>(IQueryable<T> query)
    {
        var result = new List<T>();

        var iterator = query.ToFeedIterator();

        while (iterator.HasMoreResults)
        {
            var feedResponse = await iterator.ReadNextAsync();

            result.AddRange(feedResponse.ToList());
        }

        return result;
    }
}