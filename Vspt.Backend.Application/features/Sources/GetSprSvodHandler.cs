using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Sources;

public sealed record GetSprSvodRequest : BaseRequest<Unit, IReadOnlyList<SprSvod>>
{
}
internal sealed class GetSprSvodHandler : BaseRequestHandler<GetSprSvodRequest, Unit, IReadOnlyList<SprSvod>>
{
    private readonly ISprSvodRepository _sprSvodRepository;



    public GetSprSvodHandler(ISprSvodRepository sprSvodRepository)
    {
        _sprSvodRepository = sprSvodRepository;
    }

    protected override async Task<IReadOnlyList<SprSvod>> HandleData(Unit unit, CancellationToken cancellationToken)
    {
        return await _sprSvodRepository.GetSprSvod(cancellationToken);
       
    }
}
