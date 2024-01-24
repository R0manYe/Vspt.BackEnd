using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Role;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class SprDistrictRepository : EntityRepository<PgContext, SprDistrict>, ISprDistrictsRepository
{
    public SprDistrictRepository(PgContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<SprDistrict>> GetAllDistricts(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }   
}
