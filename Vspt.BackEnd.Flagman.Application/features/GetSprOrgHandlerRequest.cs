using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetSprOrgHandlerRequest : BaseRequest<Unit,List<Spr_org>>
    {
    }
    internal sealed class GetSprOrgHandler : BaseRequestHandler<GetSprOrgHandlerRequest,Unit, List<Spr_org>>
    {
        private readonly ISprOrgRepository _sprOrgRepository;

        public GetSprOrgHandler(ISprOrgRepository sprOrgRepository)
        {
           _sprOrgRepository = sprOrgRepository;
        }

        protected override async Task<List<Spr_org>> HandleData (Unit unit, CancellationToken cancellationToken)
        {
            return await  _sprOrgRepository.GetSprOrg(cancellationToken);
        }
    }
}
