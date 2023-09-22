using MassTransit;
using MassTransit.Initializers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.GetFlagman;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Application.features.GetUser
{
    public sealed record GetUserHandlerRequest : BaseRequest<string, IEnumerable<GetVsptSubjectPersoneDTO>>
    {
    }
    internal sealed class GetUsersHandlerHandler : BaseRequestHandler<GetUserHandlerRequest, string, IEnumerable<GetVsptSubjectPersoneDTO>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IFlagmanApiClient _flagmanApiClient;


        public GetUsersHandlerHandler(
            IUsersRepository usersRepository,
            IFlagmanApiClient flagmanApiClient)
        {
            _usersRepository = usersRepository;
            _flagmanApiClient = flagmanApiClient;
        }

        protected override async Task<IEnumerable<GetVsptSubjectPersoneDTO>> HandleData(string request, CancellationToken cancellationToken)
        {
            var existUsers = await _usersRepository.GetAllUsers(cancellationToken);
            var existingUserFlagman = await _flagmanApiClient.GetVsptSubject(cancellationToken);

            var exitingUser = existUsers.Select(x => new GetVsptSubjectPersoneDTO
            {
                Username = x.Username,
                Password = x.Password,
                RefreshToken = x.RefreshToken,
                Email = x.Email,
                RefreshTokenExpiryTime = x.RefreshTokenExpiryTime,
                Role = x.Role,
                Token = x.Token,
                BU = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.BU).FirstOrDefault(),
                BU_ID = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.BU_ID).FirstOrDefault(),
                DIV_ID = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.DIV_ID).FirstOrDefault(),
                DIV_NAME = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.DIV_NAME).FirstOrDefault(),
                FIRST_NAME = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.FIRST_NAME).FirstOrDefault(),
                SECOND_NAME = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.SECOND_NAME).FirstOrDefault(),
                LAST_NAME = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.LAST_NAME).FirstOrDefault(),
                PROF = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.PROF).FirstOrDefault(),
                PROF_ID = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.PROF_ID).FirstOrDefault(),
                FIO = existingUserFlagman.Where(b => b.ID == x.Username).Select(b => b.FIO).FirstOrDefault()
            }).Where(x=>x.Username==request);
            return exitingUser;
        }
    }
}
