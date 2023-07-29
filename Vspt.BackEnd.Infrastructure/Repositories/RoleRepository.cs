using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.EfCore;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.BackEnd.Application.features.Authentication.DTO;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class RoleRepository : EntityRepository<PgContext, IdentityRoles>, IRolesRepository
{
    public RoleRepository(PgContext context) : base(context)
    {
    }   

    //public Task Add(IdentityRoles entity, CancellationToken cancellationToken)
    //{
    //    return _entityDbSet.AddAndSave(entity, cancellationToken);
    //}

   
}
