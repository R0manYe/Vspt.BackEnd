using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Markup;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

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
        public Task AddClaims( GetClaimRequest claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = claimName });
        }      

        [HttpDelete("delete/{id}")]
        public Task DeleteClaims(Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = new() { Id = id } });
        }

        [HttpPost("readCliamType")]
        public Task<IReadOnlyList<TypeClaims>> ReadTypeClaims()
        {
            return _mediator.Send(new GetReadTypeClaimRequest { Data = Unit.Value });
        }
    }
}
