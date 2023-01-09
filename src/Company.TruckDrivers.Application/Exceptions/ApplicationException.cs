namespace Company.TruckDrivers.Application.Exceptions;

public class ApplicationException : Exception
{
    
    
    public ApplicationException(string message, ErrorType errorType) : base(message)
    {
        
    }

    public ErrorType ErrorType { get; }
}

public enum ErrorType
{
    ResourceNotFound,
    ValidationError
}