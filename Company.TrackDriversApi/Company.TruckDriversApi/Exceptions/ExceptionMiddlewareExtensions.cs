using Company.TruckDrivers.Application.Exceptions;
using ApplicationException = Company.TruckDrivers.Application.Exceptions.ApplicationException;

namespace Company.TruckDriversApi.Exceptions;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionMiddleware> _logger;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (Exception exception)
        {
            
            if (exception is ApplicationException applicationException)
            {
                context.Response.StatusCode = applicationException.ErrorType == ErrorType.ResourceNotFound ? 404 : 500;
                await context.Response.WriteAsJsonAsync(applicationException.ToProblemDetails());
            }
            else
            {
                _logger.LogError(exception, exception.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(exception.ToProblemDetails());
            }
        }
    }
}