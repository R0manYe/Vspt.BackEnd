using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Sources;

public sealed record GetReadDistrictsRequest : BaseRequest<Unit, IReadOnlyList<GetFilterIdNameDTO>>
{
}
internal sealed class GetReadDistrictsHandler : BaseRequestHandler<GetReadDistrictsRequest, Unit, IReadOnlyList<GetFilterIdNameDTO>>
{
    private readonly ISprDistrictsRepository _sprDistrictsRepository;



    public GetReadDistrictsHandler(ISprDistrictsRepository sprDistrictsRepository)
    {
        _sprDistrictsRepository = sprDistrictsRepository;
    }

    protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData(Unit unit, CancellationToken cancellationToken)
    {
        var result = await _sprDistrictsRepository.GetAllDistricts(cancellationToken);
        return result.Where(x=>x.Id!="1").Select(x => new GetFilterIdNameDTO { Id = x.Id, Name = x.Name }).ToList();
    }
}
