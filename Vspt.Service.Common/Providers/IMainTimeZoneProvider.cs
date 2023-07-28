using System;

namespace Vspt.Service.Common.Providers;

public interface IMainTimeZoneProvider
{
    public TimeZoneInfo MainTimeZoneInfo { get; }
}
