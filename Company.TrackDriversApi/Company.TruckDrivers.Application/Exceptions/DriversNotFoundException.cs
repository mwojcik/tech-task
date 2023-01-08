namespace Company.TruckDrivers.Application.Exceptions;

public class DriversNotFoundException : ApplicationException
{
    public DriversNotFoundException() : base("Drivers Not Found", ErrorType.ResourceNotFound)
    {
    }
}