using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grotem.Box.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Vspt.Box.Security;
using Vspt.Box.Security.Extensions;
using Vspt.Box.Security.Sessions;

namespace Vspt.Box.RefitApiClient;

internal sealed class RefitHttpMessageHandler : DelegatingHandler
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public RefitHttpMessageHandler(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		// We use it because https://andrewlock.net/understanding-scopes-with-ihttpclientfactory-message-handlers/
		var sessionService = _httpContextAccessor.GetHttpContext().RequestServices.GetRequiredService<ISessionService>();

		var currentUser = sessionService.TryGetCurrentUser();
		if (currentUser != null)
		{
			request.Headers.Add(SupportedHeaderNames.CurrentUserHeaderName, currentUser.ToJson());
		}

		if (!request.Options.TryGetValue(HttpRequestMessageOptions.RestMethodInfoKey, out var restMethodInfo))
		{
			throw new InvalidOperationException();
		}

		if (restMethodInfo.DeserializedResultType == typeof(FileResult))
		{
			SetShouldDisposeResponseToFalse(restMethodInfo);
		}

		try
		{
			return await base.SendAsync(request, cancellationToken);
		}
		catch (HttpRequestException e)
		{
			throw new ApiClientException(e.Message, e.StatusCode ?? HttpStatusCode.BadGateway);
		}
	}

	private static void SetShouldDisposeResponseToFalse(RestMethodInfo restMethodInfo)
	{
		if (!restMethodInfo.ShouldDisposeResponse)
		{
			return;
		}

		var property = typeof(RestMethodInfo).GetProperty(nameof(RestMethodInfo.ShouldDisposeResponse)) ?? throw new InvalidOperationException();
		var setter = property.SetMethod ?? throw new InvalidOperationException();
		setter.Invoke(restMethodInfo, new object?[] { false });
	}
}
