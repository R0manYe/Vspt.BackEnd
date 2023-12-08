using Vspt.BackEnd.Domain.Entity;

namespace Vspt.BackEnd.Domain.Contract
{
    public interface IRolesRepository
    {
        Task AddRoles(IdentityRoles entity, CancellationToken cancellationToken);
        Task UpdateRoles(IdentityRoles entity, CancellationToken cancellationToken);
        Task DeleteRoles(byte Id, CancellationToken cancellationToken);
        Task<IReadOnlyList<IdentityRoles>> GetReadRoles(CancellationToken cancellationToken);
    }
}