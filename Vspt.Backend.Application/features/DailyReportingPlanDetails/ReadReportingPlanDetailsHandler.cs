using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record ReadRepotingPlanDetailsRequest : BaseRequest<uint, IReadOnlyList<DailyReportingPlansDetails>>
    {
    }
    internal sealed class ReadRepotingPlanDetailsHandler : BaseRequestHandler<ReadRepotingPlanDetailsRequest, uint, IReadOnlyList<DailyReportingPlansDetails>>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;
        private readonly IFilterUserFilialsService _filterUserFilialsService;


        public ReadRepotingPlanDetailsHandler(
            IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository,
            IFilterUserFilialsService filterUserFilialsService
            )
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
            _filterUserFilialsService = filterUserFilialsService;
        }

        protected override async Task<IReadOnlyList<DailyReportingPlansDetails>> HandleData(uint userId, CancellationToken cancellationToken)
        {
            var filials = await _filterUserFilialsService.GetIdFilials(userId, cancellationToken);
            return await _dailyReportingPlanDetailsRepository.GetReadDailyReportingPlanDetails(filials, cancellationToken);
        }
    }
}
