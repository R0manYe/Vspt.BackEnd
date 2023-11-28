using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Markup;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Application.features.IdentityRolees;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<IdentityRoles>> ReadRoles()
        {
            return _mediator.Send(new GetReadRoleRequest { Data = Unit.Value });
        }

        [HttpPost("add")]
        public Task AddRole([FromBody] GetRoleRequest request)
        {
            return _mediator.Send(new GetAddRoleRequest { Data = request });
        }

        [HttpPut("update/{id}")]
        public Task UpdateCRole( Guid id,IdentityRoles request) 
        {
            return _mediator.Send(new GetUpdateRoleRequest { Data = new() { Id = id, RoleName=request.RoleName }  } );
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteRole(Guid id) 
        {
            return _mediator.Send(new GetDeleteRoleRequest { Data = new() { Id = id } });
        }
    }
}
