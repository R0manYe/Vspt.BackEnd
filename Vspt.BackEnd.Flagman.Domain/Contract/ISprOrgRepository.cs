using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface ISprOrgRepository
    {
        Task<List<Spr_org>> GetSprOrg(CancellationToken cancellationToken);
    }
}