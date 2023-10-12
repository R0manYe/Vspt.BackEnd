using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetSprCargoHandlerRequest : BaseRequest<Unit, IReadOnlyList<GetFilterIdNameDTO>>
    {
    }
    internal sealed class GetSprCargoHandler : BaseRequestHandler<GetSprCargoHandlerRequest,Unit, IReadOnlyList<GetFilterIdNameDTO>>
    {
        private readonly ISprCargoRepository _sprCargoRepository;

        public GetSprCargoHandler(ISprCargoRepository sprCargoRepository)
        {
           _sprCargoRepository = sprCargoRepository;
        }

        protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData (Unit unit, CancellationToken cancellationToken)
        {
            return await  _sprCargoRepository.GetSprCargo(cancellationToken);
        }
    }
}
