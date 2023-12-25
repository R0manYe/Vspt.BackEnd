using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class DailyReportingPlanRepository : EntityRepository<PgContext, DailyReportingPlans>, IDailyReportingPlansRepository
{
    public DailyReportingPlanRepository(PgContext context) : base(context)
    {
    }
    public async Task<IReadOnlyList<DailyReportingPlans>> ReadDailyReportingPlans(IReadOnlyList<GetFilterIdResponseDTO> Filials, CancellationToken cancellationToken)
    {
        return await _entityDbSet.Where(x => Filials.Select(y => y.Id).Contains(x.idFilial)).ToListAsync(cancellationToken);
    }
    public Task AddDailyReportingPlans(DailyReportingPlans entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }
    public Task UpdateDailyReportingPlans(DailyReportingPlans entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
    }
    public async Task DeleteDailyReportingPlans(Guid id, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }
}

   
