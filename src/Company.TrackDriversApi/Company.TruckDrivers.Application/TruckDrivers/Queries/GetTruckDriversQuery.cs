using MediatR;

namespace Company.TruckDrivers.Application.TruckDrivers.Queries;

public class GetTruckDriversQuery : IRequest<GetTruckDriversQueryResponse>
{
    public GetTruckDriversQuery(string? location = null)
    {
        Location = location;
    }

    public string? Location { get; }
}

public class GetTruckDriversQueryResponse
{
    public GetTruckDriversQueryResponse(List<TruckDriverDto> data)
    {
        Data = data;
    }

    public List<TruckDriverDto> Data { get; }
}