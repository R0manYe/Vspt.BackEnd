using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<IdentityClaims>> ReadClaims()
        {
            return _mediator.Send(new GetReadClaimRequest { Data = Unit.Value });
        }

        [HttpPost("add")]
        public Task AddIdentityClaims(GetIdentityClaimRequestDTO claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = claimName });
        }      

        [HttpDelete("delete/{id}")]
        public Task DeleteClaims(Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = id } );
        }

        [HttpGet("readClaimType")]
        public Task<IReadOnlyList<TypeClaims>> ReadTypeClaims()
        {
            return _mediator.Send(new GetReadTypeClaimRequest { Data = Unit.Value });
        }

        [HttpPost("readMenuClaim")]
        public Task<IReadOnlyList<GetFilterIdRequestDTO>> ReadTypeClaims(uint userId)
        {
            return _mediator.Send(new GetMenuRoleRequest { Data = userId });
        }
    }
}
