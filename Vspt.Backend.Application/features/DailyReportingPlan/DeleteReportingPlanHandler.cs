using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record DeleteReportingPlanRequest : BaseRequest<Guid, Unit>
    {
    }
    internal sealed class DeleteReportingPlanHandler : BaseRequestHandler<DeleteReportingPlanRequest, Guid, Unit>
    {
        private readonly IDailyReportingPlansRepository _dailyReportingPlanRepository;



        public DeleteReportingPlanHandler(IDailyReportingPlansRepository dailyReportingPlanRepository)
        {
            _dailyReportingPlanRepository = dailyReportingPlanRepository;
        }

        protected override async Task<Unit> HandleData(Guid id, CancellationToken cancellationToken)
        {
            await _dailyReportingPlanRepository.DeleteDailyReportingPlans(id, cancellationToken);
            return Unit.Value;
        }
    }
}
