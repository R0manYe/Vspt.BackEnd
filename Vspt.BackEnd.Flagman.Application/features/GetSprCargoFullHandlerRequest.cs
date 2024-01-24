using MediatR;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Flagman.Application.features
{
    public sealed record GetSprCargoFullHandlerRequest : BaseRequest<Unit,IReadOnlyList<Spr_cargo>>
    {
    }
    internal sealed class GetSprCargoFullHandler : BaseRequestHandler<GetSprCargoFullHandlerRequest,Unit, IReadOnlyList<Spr_cargo>>
    {
        private readonly ISprCargoRepository _sprCargoRepository;

        public GetSprCargoFullHandler(ISprCargoRepository sprCargoRepository)
        {
           _sprCargoRepository = sprCargoRepository;
        }

        protected override async Task<IReadOnlyList<Spr_cargo>> HandleData (Unit unit, CancellationToken cancellationToken)
        {
            return await  _sprCargoRepository.GetSprCargoFull(cancellationToken);
        }
    }
}
