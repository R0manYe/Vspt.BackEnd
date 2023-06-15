using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.Authentication;

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

        [HttpPost("autenticate")]
        public async Task<GetLoginResponse> Autenticate(GetLoginRequestItem request)
        {
            return await _mediator.Send(new GetLoginRequest { Data = request });
        }

        [HttpPost("register")]
        public  Task RegisterUser(GetLoginRequestItem request)
        {
            return  _mediator.Send(new GetRegisterRequest { Data = request });
        }

        [HttpPost("Add")]
        public Task AddUser(GetLoginRequestItem request)
        {
            return _mediator.Send(new GetAddUserRequest { Data = request });
        }
    }
}
