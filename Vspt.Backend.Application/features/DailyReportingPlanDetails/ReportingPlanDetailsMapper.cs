using AutoMapper;
using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Auth;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Application.features.DailyReportingPlanDetails;

internal sealed class ReportingPlanDetailsMapper : Profile
{
    public ReportingPlanDetailsMapper()
    {
        CreateMap<DailyReportingPlansDetails, DailyReportingPlansDetailsDTO>();
        CreateMap<DailyReportingPlansDetailsDTO, DailyReportingPlansDetails>();
        CreateMap<AddDailyReportingPlansDetailsDTO, DailyReportingPlansDetails>();
        CreateMap<DailyReportingPlansDetails,AddDailyReportingPlansDetailsDTO>();
    }
}
