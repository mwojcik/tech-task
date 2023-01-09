using Company.TruckDrivers.Application.Exceptions;
using Company.TruckDrivers.Application.TruckDrivers.Queries;
using Company.TruckDrivers.Domain.TruckDrivers;
using FluentAssertions;
using Moq;

namespace Company.TruckDrivers.Tests.UnitTests;

public class GetTruckDriversQueryHandlerTests
{
    private readonly GetTruckDriversQueryHandler _queryHandler;


    public GetTruckDriversQueryHandlerTests()
    {
         _queryHandler = new GetTruckDriversQueryHandler(InMemoryDatabase.GetTruckDrivers(), new MockDocumentMapper());
    }


    [Test]
    public async Task get_truck_drivers_should_return_all_drivers_where_location_is_not_set()
    {
        // Arrange
        var query = new GetTruckDriversQuery();

        // Act
        var actual = await _queryHandler.Handle(query, default);

        // Assert
        actual.Data.Should().NotBeEmpty().And.HaveCount(5);
    }

    [Test]
    public async Task get_truck_drivers_filtered_by_location_should_return_all_drivers_match_the_city_location()
    {
        // Arrange
        var query = new GetTruckDriversQuery("Berlin");

        // Act
        var actual = await _queryHandler.Handle(query, default);

        // Assert
        actual.Data.Should().NotBeEmpty().And.HaveCount(2);
    }


    [Test]
    public async Task get_truck_drivers_should_throw_drivers_not_found_exception_exception_when_not_found_any_drivers()
    {
        // Arrange
        var query = new GetTruckDriversQuery("Aaaaa");

        // Act
        var act = async () => { await _queryHandler.Handle(query, default); };

        // Assert
        await act.Should().ThrowAsync<DriversNotFoundException>();
    }
}