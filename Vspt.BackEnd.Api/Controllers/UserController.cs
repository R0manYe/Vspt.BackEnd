﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        
    }
}
