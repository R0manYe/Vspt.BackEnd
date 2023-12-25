using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Flagman.ApiClients;

public partial interface IFlagmanSprOrgApiClient
	{		
		/// <summary>
		/// Выборка организаций
		/// </summary>
		
    [Post("/api/Flagman/vspt_spr_org")]
    Task<IReadOnlyList<Spr_org>> GetSprOrg(IReadOnlyList<GetFilterIdRequestDTO> stations, CancellationToken cancellationToken = default);

}
