using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Vspt.Box.Security.Sessions;

public record CurrentUser
{
	public Guid Id { get; init; }

	public Guid? TenantId { get; init; }

	public IReadOnlyList<string>? RawPermissions { get; set; }

	public string ToJson()
	{
		return JsonSerializer.Serialize(this, _jsonSerializerOptions);
	}

	private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
		TypeInfoResolver = new DefaultJsonTypeInfoResolver
		{
			Modifiers = { ReadOnlyListModifier }
		},
	};

	private static void ReadOnlyListModifier(JsonTypeInfo typeInfo)
	{
		foreach (var property in typeInfo.Properties)
		{
			if (typeof(IReadOnlyList<string>).IsAssignableFrom(property.PropertyType))
			{
				property.ShouldSerialize = (_, value) =>
				{
					return value is IReadOnlyList<object> collection && collection.Count > 0;
				};
			}
		}
	}

	public static CurrentUser? TryParse(string json)
	{
		try
		{
			return JsonSerializer.Deserialize<CurrentUser>(json, _jsonSerializerOptions);
		}
		catch (JsonException)
		{
			return null;
		}
	}
}
