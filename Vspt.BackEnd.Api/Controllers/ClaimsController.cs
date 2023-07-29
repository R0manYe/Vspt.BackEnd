using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiss.Common.Api.Contracts.Pagination;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;

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

        [HttpPost("read")]
        public Task<IReadOnlyList<IdentityClaims>> ReadClaims(Paging request)
        {
            return _mediator.Send(new GetReadClaimRequest { Data = request });
        }
        [HttpPost("add")]
        public Task AddClaims([FromBody] string claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = new() { ClaimName = claimName } });
        }
        [HttpPatch("update")]
        public Task UpdateClaims([FromBody] IdentityClaims request) 
        {
            return _mediator.Send(new GetUpdateClaimRequest { Data = request} );
        }

        [HttpDelete("delete")]

        public Task DeleteClaims(Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = new() { Id = id } });
        }
    }
}
