using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.GetUser;
using Vspt.BackEnd.Application.features.IdentityClaimes;
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

    [HttpGet("read")]
    public async Task<IEnumerable<GetVsptSubjectPersoneDTO>> GetAllUsers()
    {
        return await _mediator.Send(new GetAllUsersHandlerRequest { Data=Unit.Value });
    }
    [HttpGet("User")]
    public async Task<IEnumerable<GetVsptSubjectPersoneDTO>> GetUser(uint request)
    {
        return await _mediator.Send(new GetUserHandlerRequest { Data=request });
    }
    [HttpDelete("delete/{userId}")]
    public Task UserDelete(uint userId)
    {
        return _mediator.Send(new GetDeleteUserRequest { Data = userId });
    }
    [HttpPatch("update/{userId}")]
    public Task UpdateUser(uint userId, IdentityUsers request)
    {
        return _mediator.Send(new GetUpdateUserRequest { Data = new() { Username=userId, Password=request.Password, Role=request.Role } });
    }
}
