using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetDeleteUserRequest : BaseRequest<uint, Unit>
    {
    }
    internal sealed class GetDeleteUserHandler : BaseRequestHandler<GetDeleteUserRequest, uint, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public GetDeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        protected override async Task<Unit> HandleData(uint userId, CancellationToken cancellationToken)
        {         
            await _usersRepository.DeleteUser(userId, cancellationToken);
            return Unit.Value;
        }
    }
}
