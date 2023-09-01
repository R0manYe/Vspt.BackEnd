using Vspt.Box.RefitApiClient;

namespace Tiss.Pricing.PublicModels;

public sealed record FlagmanApiClientSettings : ApiClientSettings
{
	public int ProductsBatchSize { get; set; }
}
