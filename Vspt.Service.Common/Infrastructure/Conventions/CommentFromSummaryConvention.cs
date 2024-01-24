using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Vspt.Service.Common.Infrastructure.Conventions.XmlDocumentation;

namespace Vspt.Service.Common.Infrastructure.Conventions;

public class CommentFromSummaryConvention :
    IEntityTypeAddedConvention,
    IPropertyAddedConvention
{
    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
    {
        var comment = TryGetEntityTypeComment(entityTypeBuilder.Metadata.ClrType);
        if (comment == null)
        {
            return;
        }

        entityTypeBuilder.HasComment(comment);
    }

    private static string TryGetEntityTypeComment(Type entityType)
    {
        if (entityType == null)
        {
            return null;
        }

        var documentationFile = XmlDocumentationStore.Instance.GetXmlDocumentationFile(entityType.Assembly);

        return documentationFile.TryGetSummary(entityType);
    }

    public void ProcessPropertyAdded(IConventionPropertyBuilder propertyBuilder, IConventionContext<IConventionPropertyBuilder> context)
    {
        var comment = TryGetPropertyComment(propertyBuilder.Metadata.PropertyInfo);
        if (comment == null)
        {
            return;
        }

        propertyBuilder.HasComment(comment);
    }

    private static string TryGetPropertyComment(PropertyInfo propertyInfo)
    {
        if (propertyInfo == null)
        {
            return null;
        }

        var documentationFile = XmlDocumentationStore.Instance.GetXmlDocumentationFile(propertyInfo.DeclaringType.Assembly);

        var propertySummary = documentationFile.TryGetSummary(propertyInfo);

        var propertyTypeDescription = TryGetPropertyTypeDescription(propertyInfo.PropertyType);

        if (propertySummary == null)
        {
            return propertyTypeDescription;
        }

        if (propertyTypeDescription == null)
        {
            return propertySummary;
        }

        var separator = propertySummary.Contains('\n') ? "\n" : ": ";
        return propertySummary + separator + propertyTypeDescription;
    }

    private static string TryGetPropertyTypeDescription(Type type)
    {
        type = Nullable.GetUnderlyingType(type) ?? type;

        if (!type.IsEnum)
        {
            return null;
        }

        var documentationFile = XmlDocumentationStore.Instance.GetXmlDocumentationFile(type.Assembly);

        return string.Join("\n", GetLines());

        IEnumerable<string> GetLines()
        {
            var hasFlagsAttribute = type.IsDefined(typeof(FlagsAttribute), inherit: false);
            var summary = documentationFile.TryGetSummary(type);
            yield return $"{(hasFlagsAttribute ? "[Flags] " : "")}{type.Name}:{MakeInlineComment(summary)}";

            var enumUnderlyingType = type.GetEnumUnderlyingType();

            var members = Enum
                .GetNames(type)
                .Select(name =>
                {
                    var value = Convert.ChangeType(Enum.Parse(type, name), enumUnderlyingType);

                    var summary = documentationFile.TryGetSummary(type.GetField(name));

                    return new { Name = name, Value = value, Summary = summary };
                })
                .OrderBy(x => x.Value)
                .ThenBy(x => x.Name);

            foreach (var member in members)
            {
                var suffix = MakeInlineComment(member.Summary);
                yield return FormattableString.Invariant($"- {member.Name} = {member.Value}{suffix}");
            }
        }
    }

    private static string MakeInlineComment(string text)
    {
        return text == null ? "" : " # " + GetFirstLine(text);
    }

    private static string GetFirstLine(string text)
    {
        var newLineIndex = text.IndexOf('\n');
        if (newLineIndex == -1)
        {
            return text;
        }

        return text.Substring(0, newLineIndex);
    }
}
