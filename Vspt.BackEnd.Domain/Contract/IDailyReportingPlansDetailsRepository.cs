using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IDailyReportingPlansDetailsRepository
    {      
        Task<IReadOnlyList<DailyReportingPlansDetails>> GetReadDailyReportingPlanDetails(IReadOnlyList<GetFilterIdResponseDTO> filials,CancellationToken cancellationToken);
        Task AddDailyReportingPlanDetails(DailyReportingPlansDetails entity, CancellationToken cancellationToken);
        Task UpdateDailyReportingPlanDetails(DailyReportingPlansDetails entity, CancellationToken cancellationToken);
        Task DeleteDailyReportingPlanDetails(Guid id, CancellationToken cancellationToken);
    }
}