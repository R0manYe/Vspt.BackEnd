using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Vspt.Box.RefitApiClient;

public abstract record ApiClientSource
{
    public abstract IEnumerable<Type> GetApiClients();

    public static ApiClientSource FromAssemblyContaining(Type type)
    {
        var assembly = type.Assembly;

        return new AssemblyApiClientSource
        {
            Assembly = assembly,
            Namespace = assembly.GetName().Name ?? throw new InvalidOperationException(),
        };
    }

    public static ApiClientSource FromSiblingsOfType(Type type)
    {
        return new AssemblyApiClientSource
        {
            Assembly = type.Assembly,
            Namespace = type.Namespace,
        };
    }

    private sealed record AssemblyApiClientSource : ApiClientSource
    {
        public required Assembly Assembly { get; init; }

        public string? Namespace { get; init; }

        public override IEnumerable<Type> GetApiClients()
        {
            return Assembly.ExportedTypes
                .Where(type => Namespace == null || type.Namespace == Namespace)
                .Where(type => type.IsInterface);
        }
    }
}
