using Company.TruckDrivers.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ApplicationException = Company.TruckDrivers.Application.Exceptions.ApplicationException;

namespace Company.TruckDriversApi.Exceptions;

public static class ExceptionExtensions
{
    public static ProblemDetails ToProblemDetails(this ApplicationException exception)
    {
        var error = new ValidationProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Status = exception.ErrorType == ErrorType.ResourceNotFound ? 404 : 400,
            Title = "One or more validation errors occurred.",
            Detail = exception.Message
        };

        return error;
    }

    public static ProblemDetails ToProblemDetails(this Exception exception)
    {
        var error = new ValidationProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Status = 500,
            Title = "An error occurred while processing your request."
        };

        return error;
    }
}