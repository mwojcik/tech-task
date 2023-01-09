using Company.TruckDrivers.Shared;

namespace Company.TruckDrivers.Domain.TruckDrivers;

public class TruckDriver : IDocument
{
    public string Id { get;  set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public LocationData? Location { get;  set; }

    public TruckDriver(string firstName, string lastName)
    {
        Id = Guid.NewGuid().ToString();
        FirstName = firstName;
        LastName = lastName;
    }

    public void ChangeFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void ChangeLastName(string lastName)
    {
        LastName = lastName;
    }

    public TruckDriver SetLocation(LocationData location)
    {
        Location = location;
        return this;
    }

    public DocumentIdentity GetIdentity()
    {
        return new TruckDriverIdentity(Id);
    }
}


public class TruckDriverIdentity : DocumentIdentity<TruckDriver>
{
    public TruckDriverIdentity(string id)
        : base(id)
    {
    }
}