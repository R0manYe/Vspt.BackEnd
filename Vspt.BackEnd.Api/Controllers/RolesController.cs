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
        public Task<IReadOnlyList<IdentityRoles>> ReadClaims()
        {
            return _mediator.Send(new GetReadRoleRequest { Data = Unit.Value });
        }

        [HttpPost("add")]
        public Task AddClaims( GetRoleRequest roleName)
        {
            return _mediator.Send(new GetAddRoleRequest { Data = roleName });
        }

        [HttpPut("update/{id}")]
        public Task UpdateClaims( Guid id,IdentityClaims request) 
        {
            return _mediator.Send(new GetUpdateClaimRequest { Data = new() { Id = id, ClaimName=request.ClaimName }  } );
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteClaims([FromQuery] Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = new() { Id = id } });
        }
    }
}
