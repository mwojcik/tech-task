using Company.TruckDrivers.Application.Ports;
using Company.TruckDrivers.Domain.TruckDrivers;
using Moq;

namespace Company.TruckDrivers.Tests;

public static class InMemoryDatabase
{
    public static IDatabaseContext GetTruckDrivers()
    {
        var databaseContextMock = new Mock<IDatabaseContext>();
        databaseContextMock.Setup(x => x.Query<TruckDriver>())
            .Returns(() => new List<TruckDriver>
            {
                new TruckDriver("Adam", "Nisek").SetLocation(new LocationData("Berlin")),
                new TruckDriver("Jacek", "Kura").SetLocation(new LocationData("Berlin")),
                new("Roman", "Zilinski"),
                new("Michal", "Adamski"),
                new TruckDriver("Piotr", "Kowalski").SetLocation(new LocationData("Warszawa"))
            }.AsQueryable());

        return databaseContextMock.Object;
    }
}