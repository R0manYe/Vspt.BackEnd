using Vspt.BackEnd.Domain.Entity;


namespace Vspt.BackEnd.Domain.Contract
{
    public interface ISprSvodRepository
    {     
        Task<IReadOnlyList<SprSvod>> GetSprSvod(CancellationToken cancellationToken);
    }
}