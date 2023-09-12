using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.Pricing.ApiClients
{
	public partial interface IFlagmanApiClient
	{		
		/// <summary>
		/// Выборка пользователей
		/// </summary>	
		[Get("/api/Flagman/vspt_subject_persone")]
        Task <IReadOnlyList<Vspt_subject_personeDTO>> GetVsptSubject([Body] Paging request, CancellationToken cancellationToken = default);
		
	}
}
