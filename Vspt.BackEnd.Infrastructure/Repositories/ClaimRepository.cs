using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class ClaimRepository : EntityRepository<PgContext, IdentityClaims>, IIdentityClaimsRepository
{
    public ClaimRepository(PgContext context) : base(context)
    {
    }

    public Task AddIdentityClaim(IdentityClaims entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }

    

    public async Task DeleteClaim(Guid id, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }

    public Task UpdateClaim(IdentityClaims entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
    }

    public async Task<IReadOnlyList<IdentityClaims>> GetReadClaims(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<GetFilterIdRequestDTO>> GetDistrictsClaim(string entity, CancellationToken cancellationToken)
    {
        return await _entityDbSet
            .Where(x => x.ClaimUser == entity && x.ClaimName == 2)
            .Select(x =>new GetFilterIdRequestDTO { Id=x.ClaimValue})
            .ToListAsync(cancellationToken);
        
    }
    public async Task<IReadOnlyList<GetFilterIdRequestDTO>> GetFilialsClaim(string entity, CancellationToken cancellationToken)
    {
        return await _entityDbSet
            .Where(x => x.ClaimUser == entity && x.ClaimName == 1)
            .Select(x => new GetFilterIdRequestDTO { Id = x.ClaimValue })
            .ToListAsync(cancellationToken);

    }
}

   
