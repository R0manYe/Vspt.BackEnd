using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vspt.BackEnd.Application.features.DailyReportingPlan;
using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportingPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportingPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("read")]
        public Task<IReadOnlyList<DailyReportingPlans>> ReadDailyReportingPlanDetails(uint userId)
        {
            return _mediator.Send(new ReadRepotingPlanRequest { Data = userId });
        }

        [HttpPost("add")]
        public Task AddDailyReportingPlanDetails(DailyReportingPlans reportingPlan )
        {
            return _mediator.Send(new AddReportingPlanRequest { Data = reportingPlan});
        }
        [HttpPost("update")]
        public Task UpdateDailyReportingPlans(DailyReportingPlans reportingPlan)
        {
            return _mediator.Send(new UpdateReportingPlanRequest { Data = reportingPlan });
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteDailyReportingPlans(Guid id) 
        {
            return _mediator.Send(new DeleteReportingPlanRequest { Data = id } );
        }
       
    }
}
