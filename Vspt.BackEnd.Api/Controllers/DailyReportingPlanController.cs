using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.IdentityClaimes;
using Vspt.BackEnd.Application.features.IdentityRolees;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportingPlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportingPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<DailyReportingPlanDetails>> ReadDailyReportingPlanDetails(uint userId)
        {
            return _mediator.Send(new GetReadRepotingPlanRequest { Data = userId });
        }

        [HttpPost("add")]
        public Task AddIdentityClaims( GetIdentityClaimRequestDTO claimName)
        {
            return _mediator.Send(new GetAddClaimRequest { Data = claimName });
        }      

        [HttpDelete("delete/{id}")]
        public Task DeleteClaims(Guid id) 
        {
            return _mediator.Send(new GetDeleteClaimRequest { Data = id } );
        }
       
    }
}
