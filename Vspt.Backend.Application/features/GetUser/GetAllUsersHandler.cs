using MassTransit.Initializers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Flagman.ApiClients;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.GetFlagman;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Application.features.GetUser;

public sealed record GetAllUsersHandlerRequest : BaseRequest<Unit, IEnumerable<GetVsptSubjectPersoneDTO>>
{
}
internal sealed class GetAllUsersHandlerHandler : BaseRequestHandler<GetAllUsersHandlerRequest, Unit, IEnumerable<GetVsptSubjectPersoneDTO>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IFlagmanApiClient _flagmanApiClient;


    public GetAllUsersHandlerHandler(
        IUsersRepository usersRepository,
        IFlagmanApiClient flagmanApiClient)
    {
        _usersRepository = usersRepository;
        _flagmanApiClient = flagmanApiClient;
    }

    protected override async Task<IEnumerable<GetVsptSubjectPersoneDTO>> HandleData(Unit unit, CancellationToken cancellationToken)
    {
        var existUsers = await _usersRepository.GetAllUsers(cancellationToken);
        var existingUserFlagman = await _flagmanApiClient.GetVsptSubject(cancellationToken);

        var exitingUsers = existUsers.Select(x => new GetVsptSubjectPersoneDTO
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
        });
        return exitingUsers;
    }
}