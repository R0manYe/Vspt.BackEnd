using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.DailyReportingPlan;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportingPlansDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportingPlansDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("read")]
        public Task<IReadOnlyList<DailyReportingPlansDetailsDTO>> ReadDailyReportingPlanDetails(uint userId)
        {
            return _mediator.Send(new ReadRepotingPlanDetailsRequest { Data = userId });
        }

        [HttpPost("add")]
        public Task AddDailyReportingPlanDetails(DailyReportingPlansDetails reportingPlan )
        {
            return _mediator.Send(new AddReportingPlanDetailsRequest { Data = reportingPlan});
        }

        [HttpPost("update")]
        public Task UpdateDailyReportingPlansDetails(DailyReportingPlansDetails reportingPlan)
        {
            return _mediator.Send(new UpdateReportingPlanDetailsRequest { Data = reportingPlan });
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteDailyReportingPlansDetails(Guid id) 
        {
            return _mediator.Send(new DeleteReportingPlanDetailsRequest { Data = id } );
        }
       
    }
}
