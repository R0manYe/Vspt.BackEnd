using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetDeleteUserRequest : BaseRequest<string, Unit>
    {
    }
    internal sealed class GetDeleteUserHandler : BaseRequestHandler<GetDeleteUserRequest, string, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public GetDeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        protected override async Task<Unit> HandleData(string userId, CancellationToken cancellationToken)
        {         
            await _usersRepository.DeleteUser(userId, cancellationToken);
            return Unit.Value;
        }
    }
}
