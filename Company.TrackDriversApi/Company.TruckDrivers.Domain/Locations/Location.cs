using Company.TruckDrivers.Shared;

namespace Company.TruckDrivers.Domain.Locations;

public class Location : IDocument
{
    public Location(string city)
    {
        Id = Guid.NewGuid().ToString();
        City = city;
    }

    public string Id { get; }
    public string City { get; }
    
    public DocumentIdentity GetIdentity()
    {
        return new LocationIdentity(Id);
    }
}

public class LocationIdentity : DocumentIdentity<Location>
{
    public LocationIdentity(string id) : base(id)
    {
    }
}