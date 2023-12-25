using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetSprOrgHandlerRequest : BaseRequest<IReadOnlyList<GetFilterIdResponseDTO>, IReadOnlyList<Spr_org>>
    {
    }
    internal sealed class GetSprOrgHandler : BaseRequestHandler<GetSprOrgHandlerRequest, IReadOnlyList<GetFilterIdResponseDTO>, IReadOnlyList<Spr_org>>
    {
        private readonly ISprOrgRepository _sprOrgRepository;

        public GetSprOrgHandler(ISprOrgRepository sprOrgRepository)
        {
           _sprOrgRepository = sprOrgRepository;
        }

        protected override async Task<IReadOnlyList<Spr_org>> HandleData (IReadOnlyList<GetFilterIdResponseDTO> stations, CancellationToken cancellationToken)
        {
            return await  _sprOrgRepository.GetSprOrg(stations, cancellationToken);
        }
    }
}
