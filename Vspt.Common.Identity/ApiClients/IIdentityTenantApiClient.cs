using System;
using System.Threading;
using System.Threading.Tasks;
using Refit;


namespace Vspt.Common.Identity.ApiClients;

public interface IIdentityTenantApiClient
{
	/*[Post("/internal/tenant")]
	Task<Guid> Create([Body] CreateTenantRequestDto request, CancellationToken cancellationToken);

	[Delete("/internal/tenant/{id}")]
	Task Delete(Guid id, CancellationToken cancellationToken);

	[Get("/internal/tenant/{id}")]
	Task<GetTenantResponseDto> GetById(Guid id, CancellationToken cancellationToken);

	[Put("/internal/tenant")]
	Task Update([Body] UpdateTenantRequestDto request, CancellationToken cancellationToken);*/
}
