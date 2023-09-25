using Vspt.BackEnd.Domain.Entity;


namespace Vspt.BackEnd.Domain.Contract
{
    public interface ITypeClaimsRepository
    {     
        Task<IReadOnlyList<TypeClaims>> GetReadTypeClaims(CancellationToken cancellationToken);
    }
}