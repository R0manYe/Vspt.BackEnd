using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.EfCore;
using Vspt.Box.Data.EfCore.Entities;
using Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class UserRepository : EntityRepository<PgContext, IdentityUsers>, IUsersRepository
{
    public UserRepository(PgContext context) : base(context)
    {
    }

    public async Task<IdentityUsers> GetByUserName(uint userName, CancellationToken cancellationToken)
    {
          return await _entityDbSet.AsNoTracking().FirstAsync(x=>x.Username==userName);
    }
    public  async Task<IdentityUsers> GetByUserNamePsw(string userName, string userPsw, CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().Where(x => x.Username == uint.Parse(userName) && x.Password == userPsw).FirstAsync();       
    }

    public async Task<IdentityUsers> GetByToken(string token, CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().FirstAsync(x => x.RefreshToken == token);
    }

    public Task Add(IdentityUsers entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }   

    public async Task<List<IdentityUsers>> GetAllUsers(CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().ToListAsync();
       
    }

    public  Task GetBySaveToken(IdentityUsers user, CancellationToken cancellationToken)
    {
         return _entityDbSet.UpdateAndSave(user,cancellationToken);
    }

    public async Task DeleteUser(uint userId, CancellationToken cancellationToken)
    {
        var item = await _entityDbSet.FirstOrDefaultAsync(x => x.Username == userId, cancellationToken);

        if (item != null)
        {
            await _entityDbSet.RemoveAndSave(item, cancellationToken);
        }
    }
    public Task UpdateUser(IdentityUsers entity, CancellationToken cancellationToken)
    { 
        return _entityDbSet.UpdateAndSave(entity, cancellationToken);
        
    }
}
