using MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record DeleteReportingPlanDetailsRequest : BaseRequest<Guid, Unit>
    {
    }
    internal sealed class DeleteReportingPlanDetailsHandler : BaseRequestHandler<DeleteReportingPlanDetailsRequest, Guid, Unit>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;



        public DeleteReportingPlanDetailsHandler(IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository)
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
        }

        protected override async Task<Unit> HandleData(Guid id, CancellationToken cancellationToken)
        {
            await _dailyReportingPlanDetailsRepository.DeleteDailyReportingPlanDetails(id, cancellationToken);
            return Unit.Value;
        }
    }
}
