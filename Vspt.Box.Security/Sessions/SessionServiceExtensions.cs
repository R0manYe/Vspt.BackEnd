using Grotem.Box.Exceptions;

namespace Vspt.Box.Security.Sessions;

public static class SessionServiceExtensions
{
	public static CurrentUser GetCurrentUser(
		this ISessionService sessionService
	)
	{
		var currentUser = sessionService.TryGetCurrentUser();
		if (currentUser == null)
		{
			throw new ForbiddenException("No current user");
		}

		return currentUser;
	}
}
