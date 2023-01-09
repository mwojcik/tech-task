namespace Company.TruckDrivers.Application.Ports;

public interface IDocumentMapper
{
    Task<List<T>> ToDocumentListAsync<T>(IQueryable<T> query);
}