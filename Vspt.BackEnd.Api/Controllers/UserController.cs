using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.GetUser;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.GetFlagman;

namespace Vspt.BackEnd.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("authenticate")]
    public  Task<GetLoginResponse> Autenticate([FromBody] GetAutenticateRequest request)
    {
        return  _mediator.Send(new GetLoginRequest { Data = request });
    }

    [HttpPost("register")]
    public  Task RegisterUser([FromBody] GetLoginRequestItem request)
    {
        return  _mediator.Send(new GetRegisterRequest { Data = request });
    }

    [HttpPost("Add")]
    public Task AddUser([FromBody] GetLoginRequestItem request)
    {
        return _mediator.Send(new GetAddUserRequest { Data = request });
    }

    [HttpPost("Refresh")]
    public Task Refresh(TokenApiDto request)
    {
        return _mediator.Send(new GetRefreshRequest { Data = request });
    }

    [HttpGet("AllUser")]
    public async Task<IEnumerable<GetVsptSubjectPersoneDTO>> GtAllUsers()
    {
        return await _mediator.Send(new GetAllUsersHandlerRequest { Data=Unit.Value });
    }
    [HttpGet("User")]
    public async Task<IEnumerable<GetVsptSubjectPersoneDTO>> GtUsers(string request)
    {
        return await _mediator.Send(new GetUserHandlerRequest { Data=request });
    }
}
