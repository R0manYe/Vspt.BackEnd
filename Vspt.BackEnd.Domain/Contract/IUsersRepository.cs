using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IUsersRepository
    {
        Task<IdentityUsers> GetByUserName(string userName, CancellationToken cancellationToken);
        Task<IdentityUsers> GetByUserNamePsw(string userName, string userPsw, CancellationToken cancellationToken);

        Task<IdentityUsers> GetByToken(string token, CancellationToken cancellationToken);
        Task GetBySaveToken(IdentityUsers user, CancellationToken cancellationToken);

        Task Add(IdentityUsers entity, CancellationToken cancellationToken);

      //  Task<bool> GetAnyName(string Unit);     

        Task<List<IdentityUsers>> GetAllUsers(CancellationToken cancellationToken);
    }
}