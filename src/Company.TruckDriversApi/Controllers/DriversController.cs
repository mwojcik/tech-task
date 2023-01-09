using System.Net;
using Company.TruckDrivers.Application.TruckDrivers.Commands;
using Company.TruckDrivers.Application.TruckDrivers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.TruckDriversApi.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly IMediator _mediator;

    public DriversController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Fetch All Drivers. 
    /// </summary>
    /// <param name="location"> City where the driver is located</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails),(int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails),(int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(GetTruckDriversQueryResponse),(int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromQuery] string? location)
    {
        var result = await _mediator.Send(new GetTruckDriversQuery(location));
        return Ok(result);
    }
    
    /// <summary>
    /// Init Sample Data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        await _mediator.Send(new InitSampleDataCommand());
        return Ok();
    }
}

