using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text.Encodings.Web;
using Tiss.Common.Api.Contracts.Pagination;
using Vspt.BackEnd.Application.Authentication.Auth;
using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;
using static System.Net.Mime.MediaTypeNames;

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
        public Task AddClaims(string claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = new() { ClaimName = claimName } });
        }

        [HttpPut ("update")]
        public Task UpdateClaims(IdentityClaims request) 
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
