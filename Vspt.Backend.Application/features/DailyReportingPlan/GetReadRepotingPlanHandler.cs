using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;

namespace Vspt.BackEnd.Application.features.IdentityRolees
{
    public sealed record GetReadRepotingPlanRequest : BaseRequest<uint, IReadOnlyList<DailyReportingPlanDetails>>
    {
    }
    internal sealed class GetReadRepotingPlanHandler : BaseRequestHandler<GetReadRepotingPlanRequest, uint, IReadOnlyList<DailyReportingPlanDetails>>
    {
        private readonly IDailyReportingPlanDetailsRepository _dailyReportingPlanDetailsRepository;
        private readonly IFilterUserFilialsService _filterUserFilialsService;


        public GetReadRepotingPlanHandler(
            IDailyReportingPlanDetailsRepository dailyReportingPlanDetailsRepository,
            IFilterUserFilialsService filterUserFilialsService
            )
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
            _filterUserFilialsService = filterUserFilialsService;
        }

        protected override async Task<IReadOnlyList<DailyReportingPlanDetails>> HandleData(uint userId, CancellationToken cancellationToken)
        {
            var filials = await _filterUserFilialsService.GetIdFilials(userId, cancellationToken);
            return await _dailyReportingPlanDetailsRepository.GetReadDailyReportingPlanDetails(filials, cancellationToken);
        }
    }
}
