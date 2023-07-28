using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Api.Controllers
{
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

        [HttpGet]
        public async Task<List<IdentityUsers>> GtAllUsers()
        {
            return await _mediator.Send(new GetAllUsersHandlerRequest { Data=Unit.Value });
        }
       
    }
}
