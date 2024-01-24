using System;
using Microsoft.AspNetCore.Http;

namespace Vspt.Box.Security.Extensions;

public static class HttpContextAccessorExtensions
{
	public static HttpContext GetHttpContext(this IHttpContextAccessor httpContextAccessor)
	{
		return httpContextAccessor.HttpContext ?? throw new InvalidOperationException("No HttpContext");
	}
}
