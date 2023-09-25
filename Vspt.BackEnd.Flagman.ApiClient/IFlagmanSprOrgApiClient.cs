using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Flagman.ApiClients;

public partial interface IFlagmanSprOrgApiClient
	{		
		/// <summary>
		/// Выборка организаций
		/// </summary>	

    [Get("/api/Flagman/vspt_spr_org")]
    Task<IReadOnlyList<Spr_org>> GetSprOrg(CancellationToken cancellationToken = default);

}
