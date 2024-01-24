using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features;

public sealed record GetSprCargoGroupHandlerRequest : BaseRequest<Unit, IReadOnlyList<Spr_cargo_group>>
{
}
internal sealed class GetSprCargoGroupHandler : BaseRequestHandler<GetSprCargoGroupHandlerRequest, Unit, IReadOnlyList<Spr_cargo_group>>
{
    private readonly ISprCargoGroupRepository _sprCargoGroupRepository;

    public GetSprCargoGroupHandler(ISprCargoGroupRepository sprCargoGroupRepository)
    {
        _sprCargoGroupRepository = sprCargoGroupRepository;
    }

    protected override async Task<IReadOnlyList<Spr_cargo_group>> HandleData (Unit unit, CancellationToken cancellationToken)
    {
        return await _sprCargoGroupRepository.GetSprCargoGroup(cancellationToken);
    }
}
