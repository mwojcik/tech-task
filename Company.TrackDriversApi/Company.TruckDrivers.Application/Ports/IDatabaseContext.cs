using Company.TruckDrivers.Shared;

namespace Company.TruckDrivers.Application.Ports;

public interface IDatabaseContext
{
    IQueryable<TDocument> Query<TDocument>()
        where TDocument : class, IDocument;

    Task AddAsync<TDocument>(TDocument document) 
        where TDocument : class, IDocument;
    
    /*IQueryable2<TDocument> Query2<TDocument>()
        where TDocument : class, IDocument;*/
}

/*public interface IQueryable2<TDocument>
{
    public IQueryable<TDocument> ToListAsync();
}*/