using System.Threading;
using System.Threading.Tasks;
using Refit;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.Pricing.ApiClients
{
	public partial interface IFlagmanApiClient
	{		
		/// <summary>
		/// Выборка пользователей
		/// </summary>	
		[Get("/v1/Vspt-subject")]
        Task <List<Vspt_subject_persone>> GetVsptSubject(CancellationToken cancellationToken = default);
		
	}
}
