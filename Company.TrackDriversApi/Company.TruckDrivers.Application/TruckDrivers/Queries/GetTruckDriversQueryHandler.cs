using Company.TruckDrivers.Application.Exceptions;
using Company.TruckDrivers.Application.Ports;
using Company.TruckDrivers.Domain.TruckDrivers;
using MediatR;

namespace Company.TruckDrivers.Application.TruckDrivers.Queries;

public class GetTruckDriversQueryHandler : IRequestHandler<GetTruckDriversQuery, GetTruckDriversQueryResponse>
{
    private readonly IDatabaseContext _databaseContext;
    private readonly IDocumentMapper _documentMapper;

    public GetTruckDriversQueryHandler(IDatabaseContext databaseContext, IDocumentMapper documentMapper)
    {
        _databaseContext = databaseContext;
        _documentMapper = documentMapper;
    }

    public async Task<GetTruckDriversQueryResponse> Handle(GetTruckDriversQuery request, CancellationToken cancellationToken)
    {
        var query = _databaseContext.Query<TruckDriver>();
        
        if (!string.IsNullOrEmpty(request.Location))
        {
            query = query.Where(x => x.Location != null && x.Location.City == request.Location);
        }
        
        var result = await _documentMapper.ToDocumentListAsync(query);

        if (result.Any() == false)
        {
            throw new DriversNotFoundException();
        }
        
        var data = result.Select(Mapper.Map).ToList();
        return new GetTruckDriversQueryResponse(data);
    }
}