using AutoMapper;
using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetAddUserRequest : BaseRequest<GetLoginRequestItem, Unit>
    {
    }
    internal sealed class GetAddUserHandler : BaseRequestHandler<GetAddUserRequest, GetLoginRequestItem, Unit>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;


        public GetAddUserHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;

        }

        protected override async Task<Unit> HandleData(GetLoginRequestItem request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityUsers>(request);
            await _usersRepository.Add(user, cancellationToken);
            return Unit.Value;

        }
    }
}
