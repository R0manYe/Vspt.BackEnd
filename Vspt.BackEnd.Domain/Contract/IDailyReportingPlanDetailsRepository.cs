using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IDailyReportingPlanDetailsRepository
    {      
        Task<IReadOnlyList<DailyReportingPlanDetails>> GetReadDailyReportingPlanDetails(IReadOnlyList<GetFilterIdResponseDTO> filials,CancellationToken cancellationToken);
    }
}