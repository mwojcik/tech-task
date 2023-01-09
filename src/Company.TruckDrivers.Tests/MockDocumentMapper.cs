using Company.TruckDrivers.Application.Ports;

namespace Company.TruckDrivers.Tests;

public class MockDocumentMapper : IDocumentMapper
{
    public Task<List<T>> ToDocumentListAsync<T>(IQueryable<T> query)
    {
        var result = query.ToList();
        return Task.FromResult(result);
    }
}