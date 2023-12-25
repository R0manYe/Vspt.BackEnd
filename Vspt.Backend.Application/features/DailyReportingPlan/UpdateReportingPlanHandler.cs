using MediatR;
using System.Collections.Generic;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record UpdateReportingPlanRequest : BaseRequest<DailyReportingPlans, Unit>
    {
    }
    internal sealed class UpdateReportingPlanHandler : BaseRequestHandler<UpdateReportingPlanRequest, DailyReportingPlans, Unit>
    {
        private readonly IDailyReportingPlansRepository _dailyReportingPlansRepository;



        public UpdateReportingPlanHandler(IDailyReportingPlansRepository dailyReportingPlansRepository)
        {
            _dailyReportingPlansRepository = dailyReportingPlansRepository;
        }

        protected override async Task<Unit> HandleData(DailyReportingPlans entity, CancellationToken cancellationToken)
        {
            await _dailyReportingPlansRepository.UpdateDailyReportingPlans(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
