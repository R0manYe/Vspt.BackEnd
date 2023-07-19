using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Vspt.Service.Common.Infrastructure.Conventions.XmlDocumentation;

internal sealed class XmlDocumentationFile
{
    private sealed record Data
    {
        public static readonly Data Empty = new() { SummaryByMemberName = new Dictionary<string, string>() };

        public required IReadOnlyDictionary<string, string> SummaryByMemberName { get; init; }
    }

    private readonly Lazy<Data> _lazyData;

    private XmlDocumentationFile(Func<Data> getData)
    {
        _lazyData = new Lazy<Data>(getData);
    }

    public static XmlDocumentationFile FromAssembly(Assembly assembly)
    {
        return new XmlDocumentationFile(() =>
        {
            var path = GetXmlDocumentationFilePath(assembly);
            return ReadData(path);
        });
    }

    private static string GetXmlDocumentationFilePath(Assembly assembly)
    {
        return Path.Combine(
            Path.GetDirectoryName(assembly.Location),
            assembly.GetName().Name + ".xml"
        );
    }

    private static Data ReadData(string xmlFilePath)
    {
        var summaryByMemberName = new Dictionary<string, string>();

        foreach (var memberElement in GetMemberElements(xmlFilePath))
        {
            var memberName = memberElement.Attribute("name")?.Value ?? "";

            var summaryElement = memberElement.Element("summary");
            var summaryXml = string.Concat(summaryElement?.Nodes() ?? XElement.EmptySequence);
            var summary = XmlToText(summaryXml);

            if (memberName != "" && summary != "")
            {
                summaryByMemberName[memberName] = summary;
            }
        }

        if (summaryByMemberName.Count == 0)
        {
            return Data.Empty;
        }

        return new Data { SummaryByMemberName = summaryByMemberName };
    }

    private static string XmlToText(string xml)
    {
        if (xml == "")
        {
            return "";
        }

        var xmlWithoutTabs = ReplaceTabsWithSpaces(xml);
        var textWithWindowsLineEndings = XmlCommentsTextHelper.Humanize(xmlWithoutTabs);
        return textWithWindowsLineEndings.Replace("\r", "");
    }

    private static string ReplaceTabsWithSpaces(string textWithTabs, int tabSize = 4)
    {
        var sb = new StringBuilder(textWithTabs.Length);

        var isFirstLine = true;
        foreach (var line in textWithTabs.Split('\n'))
        {
            if (isFirstLine)
            {
                isFirstLine = false;
            }
            else
            {
                sb.Append('\n');
            }

            var lineLength = 0;
            foreach (var piece in line.Split('\t'))
            {
                sb.Append(piece);
                lineLength += piece.Length;

                var spaceCount = tabSize - lineLength % tabSize;
                sb.Append(' ', spaceCount);
                lineLength += spaceCount;
            }
        }

        return sb.ToString();
    }

    private static IEnumerable<XElement> GetMemberElements(string xmlFilePath)
    {
        var document = TryReadXml(xmlFilePath);
        if (document != null)
        {
            var root = document.Root;
            if (root != null)
            {
                var membersElement = root.Element("members");
                if (membersElement != null)
                {
                    return membersElement.Elements("member");
                }
            }
        }

        return Array.Empty<XElement>();
    }

    private static XDocument TryReadXml(string xmlFilePath)
    {
        try
        {
            return XDocument.Load(xmlFilePath);
        }
        catch (FileNotFoundException)
        {
            return null;
        }
    }

    public string TryGetSummary(MemberInfo memberInfo)
    {
        var memberName = GetMemberName(memberInfo);

        var data = _lazyData.Value;

        return data.SummaryByMemberName.GetValueOrDefault(memberName);
    }

    private static string GetMemberName(MemberInfo memberInfo)
    {
        return memberInfo switch
        {
            Type type => XmlCommentsNodeNameHelper.GetMemberNameForType(type),
            FieldInfo or PropertyInfo => XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(memberInfo),
            MethodInfo methodIndo => XmlCommentsNodeNameHelper.GetMemberNameForMethod(methodIndo),
            _ => ""
        };
    }
}
