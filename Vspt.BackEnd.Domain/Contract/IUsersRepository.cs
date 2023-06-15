using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IUsersRepository
    {
        Task<User> GetByUserName(string userName, CancellationToken cancellationToken);

        Task<User> GetByToken(string token, CancellationToken cancellationToken);

        Task Add(User entity, CancellationToken cancellationToken);

        Task<bool> GetAnyName(string Unit);

        Task<bool> GetAnyEmail(string Unit);
      
    }
}