using Vspt.Box.RefitApiClient;

namespace Vspt.Common.Identity;

public sealed record IdentityApiClientSettings : ApiClientSettings
{
	public bool UseMocks { get; set; }
}
