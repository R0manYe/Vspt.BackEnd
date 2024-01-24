using Vspt.BackEnd.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IDailyReportingPlansRepository
    {
        Task<IReadOnlyList<DailyReportingPlans>> ReadDailyReportingPlans(IReadOnlyList<GetFilterIdResponseDTO> filials, CancellationToken cancellationToken);
        Task AddDailyReportingPlans(DailyReportingPlans entity, CancellationToken cancellationToken);
        Task UpdateDailyReportingPlans(DailyReportingPlans entity, CancellationToken cancellationToken);
        Task DeleteDailyReportingPlans(Guid id, CancellationToken cancellationToken);


    }
}