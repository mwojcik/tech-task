using Company.TruckDrivers.Domain.TruckDrivers;

namespace Company.TruckDrivers.Application.TruckDrivers;

public static class Mapper
{
    public static TruckDriverDto Map(TruckDriver entity)
    {
        return new TruckDriverDto(entity.Id,entity.FirstName, entity.LastName, new LocationDto(entity.Location?.City));
    }
}