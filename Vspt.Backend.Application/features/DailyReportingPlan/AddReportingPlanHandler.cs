using MediatR;
using System.Collections.Generic;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record AddReportingPlanRequest : BaseRequest<DailyReportingPlans, Unit>
    {
    }
    internal sealed class AddReportingPlanHandler : BaseRequestHandler<AddReportingPlanRequest,DailyReportingPlans, Unit>
    {
        private readonly IDailyReportingPlansRepository _dailyReportingPlanRepository;

        public AddReportingPlanHandler(IDailyReportingPlansRepository dailyReportingPlanRepository)
        {
            _dailyReportingPlanRepository = dailyReportingPlanRepository;
        }

        protected override async Task<Unit> HandleData(DailyReportingPlans entity, CancellationToken cancellationToken)
        {
            await _dailyReportingPlanRepository.AddDailyReportingPlans(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
