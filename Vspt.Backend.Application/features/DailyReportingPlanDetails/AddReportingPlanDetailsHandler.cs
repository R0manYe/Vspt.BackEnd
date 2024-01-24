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
    public sealed record AddReportingPlanDetailsRequest : BaseRequest<AddDailyReportingPlansDetailsDTO, Unit>
    {
       
    }
    internal sealed class AddReportingPlanDetailsHandler : BaseRequestHandler<AddReportingPlanDetailsRequest, AddDailyReportingPlansDetailsDTO, Unit>
    {
        private readonly IDailyReportingPlansDetailsRepository _dailyReportingPlanDetailsRepository;
        private readonly IMapper _mapper;

        public AddReportingPlanDetailsHandler(IDailyReportingPlansDetailsRepository dailyReportingPlanDetailsRepository,IMapper mapper)
        {
            _dailyReportingPlanDetailsRepository = dailyReportingPlanDetailsRepository;
            _mapper = mapper;
        }

        protected override async Task<Unit> HandleData(AddDailyReportingPlansDetailsDTO entity, CancellationToken cancellationToken)
        {
            var dailyReport = new DailyReportingPlansDetails();

            _mapper.Map(entity,dailyReport);

            await _dailyReportingPlanDetailsRepository.AddDailyReportingPlanDetails(dailyReport, cancellationToken);
           
            return Unit.Value;
        }
    }
}
