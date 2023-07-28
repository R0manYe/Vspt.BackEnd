using System;

namespace Vspt.Service.Common.Providers;

internal sealed class MainTimeZoneProvider : IMainTimeZoneProvider
{
    public static string DefaultMainTimeZoneId { get; } = "Russian Standard Time";

    public TimeZoneInfo MainTimeZoneInfo { get; init; }

    public MainTimeZoneProvider(string timeZoneId)
    {
        MainTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }
}
