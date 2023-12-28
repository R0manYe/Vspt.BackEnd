using AutoMapper;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record ReadRepotingPlanDetailsRequest : BaseRequest<uint, IReadOnlyList<DailyReportingPlansDetailsDTO>>
    {
    }
    internal sealed class ReadRepotingPlanDetailsHandler : BaseRequestHandler<ReadRepotingPlanDetailsRequest, uint, IReadOnlyList<DailyReportingPlansDetailsDTO>>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;
        private readonly IFilterUserFilialsService _filterUserFilialsService;
        private readonly IMapper _mapper;


        public ReadRepotingPlanDetailsHandler(
            IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository,
            IFilterUserFilialsService filterUserFilialsService,
            IMapper mapper
            )
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
            _filterUserFilialsService = filterUserFilialsService;
            _mapper = mapper;
        }

        protected override async Task<IReadOnlyList<DailyReportingPlansDetailsDTO>> HandleData(uint userId, CancellationToken cancellationToken)
        {
            var filials = await _filterUserFilialsService.GetIdFilials(userId, cancellationToken);
            var exitingResult= await _dailyReportingPlanDetailsRepository.GetReadDailyReportingPlanDetails(filials, cancellationToken);
            
            var result=new List<DailyReportingPlansDetailsDTO>();

            _mapper.Map(exitingResult,result);

            return result;
         
        }
    }
}
