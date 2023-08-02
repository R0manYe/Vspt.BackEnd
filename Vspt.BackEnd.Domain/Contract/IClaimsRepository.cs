using Vspt.BackEnd.Application.features.Authentication.DTO;
using Vspt.BackEnd.Domain.Entity;


namespace Vspt.BackEnd.Domain.Contract
{
    public interface IClaimsRepository
    {
        Task Add(IdentityClaims entity, CancellationToken cancellationToken);
        Task UpdateClaim(IdentityClaims entity, CancellationToken cancellationToken);
        Task DeleteClaim(Guid Id, CancellationToken cancellationToken);
        Task<IReadOnlyList<IdentityClaims>> GetReadClaims(CancellationToken cancellationToken);
    }
}