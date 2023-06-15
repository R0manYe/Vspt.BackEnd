using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Vspt.Box.Data.EfCore.Extensions;

public static class HostExtensions
{
    public static async Task MigrateDatabase<TContext>(this IHost host, CancellationToken cancellationToken) where TContext : DbContext
    {
        using var serviceScope = host.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<TContext>();

        context.Database.SetCommandTimeout(TimeSpan.FromHours(1));

        await context.Database.MigrateAsync(cancellationToken);
    }
}
