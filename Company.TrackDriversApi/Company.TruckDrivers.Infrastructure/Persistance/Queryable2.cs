/*using Company.TruckDrivers.Application.Ports;

namespace Company.TruckDrivers.Infrastructure.Persistance;

public class Queryable2<TDocument> : IQueryable2<TDocument>
{
    public List<TDocument> ToListAsync()
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
}*/