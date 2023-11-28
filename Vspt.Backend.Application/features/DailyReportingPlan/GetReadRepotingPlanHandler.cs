using MediatR;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Repositories;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Application.features.IdentityRolees
{
    public sealed record GetReadRepotingPlanRequest : BaseRequest<string, IReadOnlyList<DailyReportingPlanDetails>>
    {
    }
    internal sealed class GetReadRepotingPlanHandler : BaseRequestHandler<GetReadRepotingPlanRequest, string, IReadOnlyList<DailyReportingPlanDetails>>
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

        protected override async Task<IReadOnlyList<DailyReportingPlanDetails>> HandleData(string userId, CancellationToken cancellationToken)
        {
            var filials = await _filterUserFilialsService.GetIdFilials(userId, cancellationToken);
            return await _dailyReportingPlanDetailsRepository.GetReadDailyReportingPlanDetails(filials, cancellationToken);
        }
    }
}
