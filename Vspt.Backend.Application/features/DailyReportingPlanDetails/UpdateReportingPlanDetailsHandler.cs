using AutoMapper;
using MediatR;
using System.Collections.Generic;
using Vspt.BackEnd.Application.Services.Filters.Filials;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Box.MediatR;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.DailyReportingPlan
{
    public sealed record UpdateReportingPlanDetailsRequest : BaseRequest<DailyReportingPlansDetailsDTO, Unit>
    {
    }
    internal sealed class UpdateReportingPlanDetailsHandler : BaseRequestHandler<UpdateReportingPlanDetailsRequest, DailyReportingPlansDetailsDTO, Unit>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;
        private readonly IMapper _mapper;

        public UpdateReportingPlanDetailsHandler(IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository, IMapper mapper)
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
            _mapper = mapper;
        }

        protected override async Task<Unit> HandleData(DailyReportingPlansDetailsDTO entity, CancellationToken cancellationToken)
        {
            var dailyReport = new DailyReportingPlansDetails();

            _mapper.Map(entity, dailyReport);

            await _dailyReportingPlanDetailsRepository.UpdateDailyReportingPlanDetails(dailyReport, cancellationToken);

            return Unit.Value;
        }
    }
}
