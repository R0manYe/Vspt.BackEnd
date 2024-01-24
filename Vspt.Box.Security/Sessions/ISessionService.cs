namespace Vspt.Box.Security.Sessions;

public interface ISessionService
{
	public CurrentUser? TryGetCurrentUser();
}
