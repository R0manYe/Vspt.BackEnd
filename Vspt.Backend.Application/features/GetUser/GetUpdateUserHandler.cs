using AutoMapper;
using MassTransit.Initializers;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Net.Sockets;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.IdentityClaimes
{
    public sealed record GetUpdateUserRequest : BaseRequest<IdentityUsers, Unit>
    {
    }
    internal sealed class GetUpdateUserHandler : BaseRequestHandler<GetUpdateUserRequest, IdentityUsers, Unit>
    {
        private readonly IUsersRepository _usersRepository;
       


        public GetUpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;             
        }

        protected override async Task<Unit> HandleData(IdentityUsers request, CancellationToken cancellationToken)
        {
            var result = await _usersRepository.GetByUserName(request.Username, cancellationToken);
            if (result != null) 
            {                
                await _usersRepository.UpdateUser(request, cancellationToken);
                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}
