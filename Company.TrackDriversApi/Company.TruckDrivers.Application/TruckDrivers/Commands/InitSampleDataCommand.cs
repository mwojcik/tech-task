using Company.TruckDrivers.Application.Ports;
using Company.TruckDrivers.Domain.TruckDrivers;
using MediatR;
using NameGenerator.Generators;

namespace Company.TruckDrivers.Application.TruckDrivers.Commands;

public class InitSampleDataCommand : IRequest
{
}

public class InitSampleDataCommandHandler : IRequestHandler<InitSampleDataCommand, Unit>
{
    private readonly IDatabaseContext _databaseContext;

    public InitSampleDataCommandHandler(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Unit> Handle(InitSampleDataCommand request, CancellationToken cancellationToken)
    {
        var nameGenerator = new RealNameGenerator();
        for (var i = 0; i < 10; i++)
        {
            var truckDriver = new TruckDriver(nameGenerator.Generate(), nameGenerator.Generate());

            if (i % 2 == 0) truckDriver.SetLocation(new LocationData("Berlin"));
            if (i % 3 == 0) truckDriver.SetLocation(new LocationData("Paris"));

            await _databaseContext.AddAsync(truckDriver);
        }

        return Unit.Value;
    }
}