using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Sources;

public sealed record GetReadFilialsRequest : BaseRequest<Unit, IReadOnlyList<GetFilterIdNameDTO>>
{
}
internal sealed class GetReadFilialsHandler : BaseRequestHandler<GetReadFilialsRequest, Unit, IReadOnlyList<GetFilterIdNameDTO>>
{
    private readonly ISprFilialsRepository _sprFilialsRepository;



    public GetReadFilialsHandler(ISprFilialsRepository sprFilialsRepository)
    {
        _sprFilialsRepository = sprFilialsRepository;
    }

    protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData(Unit unit, CancellationToken cancellationToken)
    {
        var result = await _sprFilialsRepository.GetAllFilials(cancellationToken);
        return result.Where(x=>x.Id!=1).Select(x => new GetFilterIdNameDTO { Id = x.Id, Name = x.ShortName }).ToList();
    }
}
