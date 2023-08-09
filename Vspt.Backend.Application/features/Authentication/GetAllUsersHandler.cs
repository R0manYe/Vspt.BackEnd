using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetAllUsersHandlerRequest : BaseRequest<Unit, List<IdentityUsers>>
    {
    }
    internal sealed class GetAllUsersHandlerHandler : BaseRequestHandler<GetAllUsersHandlerRequest, Unit, List<IdentityUsers>>
    {
        private readonly IUsersRepository _usersRepository;       
      

        public GetAllUsersHandlerHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository; 
        }

        protected override async Task<List<IdentityUsers>> HandleData(Unit unit, CancellationToken cancellationToken)
        {
          return await _usersRepository.GetAllUsers(cancellationToken);      
            
        }
    }
}
