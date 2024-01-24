using MediatR;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Application.Services.SprOrg;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.Filters
{
    public sealed record GetCargoHandlerRequest : BaseRequest<Unit, IReadOnlyList<GetFilterIdNameDTO>>
    {
    }
    internal sealed class GetCargoHandlerHandler : BaseRequestHandler<GetCargoHandlerRequest, Unit, IReadOnlyList<GetFilterIdNameDTO>>
    {       
        private readonly ISprCargoService _sprCargoService;

        public GetCargoHandlerHandler(
             ISprCargoService sprCargoService)
        {
            _sprCargoService = sprCargoService;

        }
        protected override async Task<IReadOnlyList<GetFilterIdNameDTO>> HandleData(Unit unit, CancellationToken cancellationToken)
        {
            return await _sprCargoService.GetSprCargo(cancellationToken);
                    
        }
    }
}
