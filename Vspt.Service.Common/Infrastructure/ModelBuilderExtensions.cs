using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Service.Common.Infrastructure;

public static class ModelBuilderExtensions
{
	public static void SeedEnumValues<T, TEnum>(this ModelBuilder mb, Func<TEnum, T> converter)
		where T : class
		where TEnum : struct, Enum
	{
		Enum.GetValues(typeof(TEnum))
			.Cast<object>()
			.Select(value => converter((TEnum)value))
			.ToList()
			.ForEach(instance => mb.Entity<T>().HasData(instance));
	}
}
