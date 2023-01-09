using System.Net;
using Company.TruckDrivers.Application.Exceptions;
using Company.TruckDriversApi.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using ApplicationException = Company.TruckDrivers.Application.Exceptions.ApplicationException;

namespace Company.TruckDrivers.Tests.ApiTests;

public class CustomExceptionMiddlewareTests
{
    [Test]
    public async Task
        custom_exception_middleware_should_return_not_found_status_when_resource_not_found_exception_was_throw()
    {
        // Arrange
        //Create a new instance of the middleware
        var middleware = new CustomExceptionMiddleware(
            innerHttpContext => throw new ApplicationException("zz", ErrorType.ResourceNotFound),
            new Mock<ILogger<CustomExceptionMiddleware>>().Object
        );

        //Create the DefaultHttpContext
        var context = new DefaultHttpContext
        {
            Response =
            {
                Body = new MemoryStream()
            }
        };

        //Call the middleware
        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.StatusCode.Should().Match(code => code == (int) HttpStatusCode.NotFound);
    }
    
    [Test]
    public async Task
        custom_exception_middleware_should_return_internal_server_error_status_when_error_occured()
    {
        // Arrange
        //Create a new instance of the middleware
        var middleware = new CustomExceptionMiddleware(
            innerHttpContext => throw new Exception("zz"),
            new Mock<ILogger<CustomExceptionMiddleware>>().Object
        );

        //Create the DefaultHttpContext
        var context = new DefaultHttpContext
        {
            Response =
            {
                Body = new MemoryStream()
            }
        };

        //Call the middleware
        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.StatusCode.Should().Match(code => code == (int) HttpStatusCode.InternalServerError);
    }
}