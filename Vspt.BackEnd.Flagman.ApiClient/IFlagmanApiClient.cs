using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Flagman.ApiClients;

public partial interface IFlagmanApiClient
	{		
		/// <summary>
		/// Выборка пользователей
		/// </summary>	
	[Get("/api/Flagman/vspt_subject_persone")]
    Task <IReadOnlyList<Vspt_subject_personeDTO>> GetVsptSubject(CancellationToken cancellationToken = default);

    [Get("/api/Flagman/vspt_subject_persone")]
    Task<IReadOnlyList<Spr_org>> GetSprOrg(CancellationToken cancellationToken = default);   
}
