using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Box.EfCore;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class TypeClaimsRepository : EntityRepository<PgContext, TypeClaims>, ITypeClaimsRepository
{
    public TypeClaimsRepository(PgContext context) : base(context)
    {
    }  
    public async Task<IReadOnlyList<TypeClaims>> GetReadTypeClaims(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync(cancellationToken);
    }

 
}

   
