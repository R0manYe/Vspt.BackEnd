using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class DailyReportingPlanDetailsRepository : EntityRepository<PgContext, DailyReportingPlansDetails>, IDailyReportingPlansDetailsRepository
{
    public DailyReportingPlanDetailsRepository(PgContext context) : base(context)
    {
    }
    
    public async Task<IReadOnlyList<DailyReportingPlansDetails>> GetReadDailyReportingPlanDetails(IReadOnlyList<GetFilterIdResponseDTO> Filials, CancellationToken cancellationToken)
    {        
        return await _entityDbSet.Where(x=>Filials.Select(y=>y.Id).Contains(x.FilialId)).ToListAsync(cancellationToken);
    }
    public Task AddDailyReportingPlanDetails(DailyReportingPlansDetails entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }
    public Task UpdateDailyReportingPlanDetails(DailyReportingPlansDetails entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
    }
    public async Task DeleteDailyReportingPlanDetails(Guid id, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }
}

   
