using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record ReadRepotingPlanRequest : BaseRequest<uint, IReadOnlyList<DailyReportingPlans>>
    {
    }
    internal sealed class ReadRepotingPlanHandler : BaseRequestHandler<ReadRepotingPlanRequest, uint, IReadOnlyList<DailyReportingPlans>>
    {
        private readonly IDailyReportingPlansRepository _dailyReportingPlanRepository;
        private readonly IFilterUserFilialsService _filterUserFilialsService;

        public ReadRepotingPlanHandler(
            IDailyReportingPlansRepository dailyReportingPlanRepository,
            IFilterUserFilialsService filterUserFilialsService
            )
        {
            _dailyReportingPlanRepository = dailyReportingPlanRepository;
            _filterUserFilialsService = filterUserFilialsService;
        }

        protected override async Task<IReadOnlyList<DailyReportingPlans>> HandleData(uint userId, CancellationToken cancellationToken)
        {
            var filials = await _filterUserFilialsService.GetIdFilials(userId, cancellationToken);
            return await _dailyReportingPlanRepository.ReadDailyReportingPlans(filials, cancellationToken);
        }
    }
}
