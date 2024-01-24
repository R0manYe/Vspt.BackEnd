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
        public Task AddDailyReportingPlanDetails(AddDailyReportingPlansDetailsDTO reportingPlan)
        {
            return _mediator.Send(new AddReportingPlanDetailsRequest { Data = reportingPlan });
        }

        [HttpPut("update/{id}")]
        public Task UpdateDailyReportingPlansDetails(Guid id, DailyReportingPlansDetailsDTO reportingPlan)
        {

            return _mediator.Send(new UpdateReportingPlanDetailsRequest
            {
                Data = new()
                {
                    Id = id,
                    BuId = reportingPlan.BuId,
                    DatePlan = reportingPlan.DatePlan,
                    ExpectedLoading = reportingPlan.LoadingPlan,
                    GruzGroupId = reportingPlan.GruzGroupId,
                    LoadingApplication = reportingPlan.LoadingApplication,
                    LoadingFirstHalfDay = reportingPlan.LoadingFirstHalfDay,
                    LoadingPlan = reportingPlan.LoadingPlan,
                    LoadingPPGT = reportingPlan.LoadingPPGT,
                    LoadingSecuredLastDay = reportingPlan.LoadingSecuredLastDay,
                    LoadingSecuredTotal = reportingPlan.LoadingSecuredTotal,
                    Notations = reportingPlan.Notations,
                    OrgId = reportingPlan.OrgId,
                    UnloadingAccesptedFullTerm = reportingPlan.UnloadingAccesptedFullTerm,
                    UnloadingAccesptedLastDayWagons = reportingPlan.UnloadingAccesptedLastDayWagons,
                    UnloadingAccesptedPPGT = reportingPlan.UnloadingAccesptedPPGT,
                    UnloadingAccesptedTotal = reportingPlan.UnloadingAccesptedTotal,
                    UnloadingExpectedLoading = reportingPlan.UnloadingExpectedLoading,
                    UnloadingPlan = reportingPlan.UnloadingPlan,
                    UnloadingProduceFullTerm = reportingPlan.UnloadingProduceFullTerm,
                    UnloadingProduceTotal = reportingPlan.UnloadingProduceTotal,
                    UnloadingRemainsFullTerm = reportingPlan.UnloadingRemainsFullTerm,
                    UnloadingRemainsGuiltConsignee = reportingPlan.UnloadingRemainsGuiltConsignee,
                    UnloadingRemainsGuiltPPGT = reportingPlan.UnloadingRemainsGuiltPPGT,
                    UnloadingRemainsLastDay = reportingPlan.UnloadingRemainsLastDay,
                    UnloadingRemainsTotal = reportingPlan.UnloadingRemainsTotal
                }
            });
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteDailyReportingPlansDetails(Guid id)
        {
            return _mediator.Send(new DeleteReportingPlanDetailsRequest { Data = id });
        }

    }
}
