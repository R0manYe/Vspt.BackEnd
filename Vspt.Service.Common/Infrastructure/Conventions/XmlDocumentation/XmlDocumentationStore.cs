using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Vspt.Service.Common.Infrastructure.Conventions.XmlDocumentation;

internal sealed class XmlDocumentationStore
{
    public static readonly XmlDocumentationStore Instance = new();

    private readonly ConcurrentDictionary<Assembly, Lazy<XmlDocumentationFile>> _files = new();

    public XmlDocumentationFile GetXmlDocumentationFile(Assembly assembly)
    {
        return _files.GetOrAdd(assembly, static key => new Lazy<XmlDocumentationFile>(() =>
        {
            return XmlDocumentationFile.FromAssembly(key);
        })).Value;
    }
}
