using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Flagman.Domain.Contract;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Flagman.Infrastructure.Repositories;

internal sealed class SprCargoRepository : EntityRepository<FlagmanContext, Spr_cargo>, ISprCargoRepository
{
    public SprCargoRepository(FlagmanContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<GetFilterIdNameDTO>> GetSprCargo(CancellationToken cancellationToken)
    {
        var result = await _entityDbSet.Select(x=>new GetFilterIdNameDTO 
        { 
            Id=x.ID, 
            Name=x.NAME
        })
            .ToListAsync();
        return result;
    }

    public async Task<IReadOnlyList<Spr_cargo>> GetSprCargoFull(CancellationToken cancellationToken)
    {

        var result =await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
        return result;

    }
}


        
