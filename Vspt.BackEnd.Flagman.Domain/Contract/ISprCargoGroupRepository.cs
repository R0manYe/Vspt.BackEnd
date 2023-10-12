using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.Contract;

public interface ISprCargoGroupRepository
{
  Task<IReadOnlyList<Spr_cargo_group>> GetSprCargoGroup(CancellationToken cancellationToken);
}