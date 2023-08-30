using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;


namespace Vspt.Common.Identity.ApiClients;

public interface IIdentityUserApiClient
{
	/*[Put("/internal/user/{id}/approve")]
	Task Approve(Guid id, CancellationToken cancellationToken);

	[Put("/internal/user/{id}/block")]
	Task Block(Guid id, CancellationToken cancellationToken);

	[Put("/internal/user/block-range")]
	Task BlockRange(List<Guid> ids, CancellationToken cancellationToken);

	[Post("/internal/user")]
	Task<Guid> Create([Body] CreateUserRequestDto request, CancellationToken cancellationToken);

	[Delete("/internal/user/{id}")]
	Task Delete(Guid id, CancellationToken cancellationToken);

	[Post("/internal/user/active")]
	Task<List<GetActiveUsersResponseItemDto>> GetActiveUsers([Body] GetActiveUsersRequestDto request, CancellationToken cancelationToken);

	[Post("/internal/user/search")]
	Task<GetAvailableUsersResponseDto> Search([Body] SearchUsersRequestDto request, CancellationToken cancellationToken = default);

	[Get("/internal/user/{id}")]
	Task<GetUserResponseDto> GetById(Guid id, CancellationToken cancellationToken = default);

	[Put("/internal/user/{id}/unblock")]
	Task Unblock(Guid id, CancellationToken cancellationToken);

	[Put("/internal/user/unblock-range")]
	Task UnblockRange(List<Guid> ids, CancellationToken cancellationToken);

	[Put("/internal/user")]
	Task Update([Body] UpdateUserRequestDto request, CancellationToken cancellationToken);*/
}
