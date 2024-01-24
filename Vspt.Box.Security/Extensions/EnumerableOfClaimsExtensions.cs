using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Vspt.Box.Security.Extensions;

internal static class EnumerableOfClaimsExtensions
{
	public static string? TryGetFirstClaimValue(this IEnumerable<Claim> claims, string claimType)
	{
		var claim = claims.FirstOrDefault(claim => claim.Type == claimType);
		return claim?.Value;
	}

	public static Guid? TryGetFirstGuidClaimValue(this IEnumerable<Claim> claims, string claimType)
	{
		var stringValue = claims.TryGetFirstClaimValue(claimType);
		if (!Guid.TryParse(stringValue, out var value))
		{
			return null;
		}

		return value;
	}

	public static IReadOnlyList<string> GetClaimValues(this IEnumerable<Claim> claims, string claimType)
	{
		return claims.Where(claim => claim.Type == claimType).Select(claim => claim.Value).ToList();
	}
}
