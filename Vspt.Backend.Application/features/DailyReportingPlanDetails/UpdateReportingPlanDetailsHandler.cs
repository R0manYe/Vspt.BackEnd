using MediatR;
using System.Collections.Generic;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record UpdateReportingPlanDetailsRequest : BaseRequest<DailyReportingPlansDetails, Unit>
    {
    }
    internal sealed class UpdateReportingPlanDetailsHandler : BaseRequestHandler<UpdateReportingPlanDetailsRequest, DailyReportingPlansDetails, Unit>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;



        public UpdateReportingPlanDetailsHandler(IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository)
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
        }

        protected override async Task<Unit> HandleData(DailyReportingPlansDetails entity, CancellationToken cancellationToken)
        {
            await _dailyReportingPlanDetailsRepository.UpdateDailyReportingPlanDetails(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
