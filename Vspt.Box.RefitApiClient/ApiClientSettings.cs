using System;

namespace Vspt.Box.RefitApiClient;

public record ApiClientSettings
{
    public Uri? Url { get; init; }

    public string? ApiKey { get; init; }

    public bool SendCurrentUser { get; init; }
}
