using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.EfCore;
using Vspt.Box.Data.EfCore.Entities;

namespace Vspt.BackEnd.Infrastructure.Repositories;

internal sealed class UserRepository : EntityRepository<PgContext, User>, IUsersRepository
{
    public UserRepository(PgContext context) : base(context)
    {
    }

    public async Task<User> GetByUserName(string userName, CancellationToken cancellationToken)
    {
          return await _entityDbSet.FirstOrDefaultAsync(x=>x.Username==userName);
    }

    public async Task<User> GetByToken(string token, CancellationToken cancellationToken)
    {
        return await _entityDbSet.FirstAsync(x => x.RefreshToken == token);
    }

    public Task Add(User entity, CancellationToken cancellationToken)
    {
        return _entityDbSet.AddAndSave(entity, cancellationToken);
    }

    public Task<bool> GetAnyName(string Unit)
    {
        return _entityDbSet.AnyAsync(x => x.Username == Unit);
    }

    public Task<bool> GetAnyEmail(string Unit)
    {
        return _entityDbSet.AnyAsync(x => x.Email == Unit);
    }

    public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        return await _entityDbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

   
}
