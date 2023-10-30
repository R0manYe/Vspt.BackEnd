using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Application.features.Sources;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<IdentityClaims>> ReadClaims()
        {
            return _mediator.Send(new GetReadClaimRequest { Data = Unit.Value });
        }
        [HttpGet("readFilials")]
        public Task<IReadOnlyList<GetFilterIdNameDTO>> ReadFilials()
        {
            return _mediator.Send(new GetReadFilialsRequest { Data = Unit.Value });
        }

    }
}
