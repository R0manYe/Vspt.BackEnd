using System;
using Microsoft.AspNetCore.Http;
using Vspt.Box.Security.Extensions;

namespace Vspt.Box.Security.Sessions;

internal sealed class HttpContextSessionService : ISessionService
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly Lazy<CurrentUser?> _lazyCurrentUser;

	public HttpContextSessionService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
		_lazyCurrentUser = new Lazy<CurrentUser?>(TryGetCurrentUserCore);
	}

	public CurrentUser? TryGetCurrentUser()
	{
		return _lazyCurrentUser.Value;
	}

	private CurrentUser? TryGetCurrentUserCore()
	{
		var claims = _httpContextAccessor.GetHttpContext().User.Claims;

		var maybeUserId = claims.TryGetFirstGuidClaimValue(SupportedClaimTypes.UserId);
		if (maybeUserId == null)
		{
			return null;
		}

		var tennantId = claims.TryGetFirstGuidClaimValue(SupportedClaimTypes.TenantId);
		var rawPermissions = claims.GetClaimValues(SupportedClaimTypes.Permission);

		return new CurrentUser
		{
			Id = maybeUserId.Value,
			TenantId = tennantId,
			RawPermissions = rawPermissions.Count == 0 ? null : rawPermissions,
		};
	}
}
