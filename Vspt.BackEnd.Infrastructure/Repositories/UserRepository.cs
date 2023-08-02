using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.EfCore;
using Vspt.Box.Data.EfCore.Entities;


namespace Vspt.BackEnd.Infrastructure.Repositories;

public class UserRepository : EntityRepository<PgContext, IdentityUsers>, IUsersRepository
{
    public UserRepository(PgContext context) : base(context)
    {
    }

    public async Task<IdentityUsers> GetByUserName(string userName, CancellationToken cancellationToken)
    {
          return await _entityDbSet.FirstAsync(x=>x.Username==userName);
    }
    public  async Task<IdentityUsers> GetByUserNamePsw(string userName, string userPsw, CancellationToken cancellationToken)
    {
        return await _entityDbSet.Where(x => x.Username == userName && x.Password == userPsw).FirstAsync();       
    }

    public async Task<IdentityUsers> GetByToken(string token, CancellationToken cancellationToken)
    {
        return await _entityDbSet.FirstAsync(x => x.RefreshToken == token);
    }

    public Task Add(IdentityUsers entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }

    //public Task<bool> GetAnyName(string Unit)
    //{
    //    return _entityDbSet.AnyAsync(x => x.Username == Unit);
    //}

    //public Task<bool> GetAnyEmail(string Unit)
    //{
    //    return _entityDbSet.AnyAsync(x => x.Email == Unit);
    //}

    public async Task<List<IdentityUsers>> GetAllUsers(CancellationToken cancellationToken)
    {
        return await _entityDbSet.ToListAsync();
    }

    public  Task GetBySaveToken(IdentityUsers user, CancellationToken cancellationToken)
    {
         return _entityDbSet.UpdateAndSave(user,cancellationToken);
    }    
}
