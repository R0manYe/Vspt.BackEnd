using System.Collections.Generic;
using System.Linq;

namespace Vspt.Box.EfCore;

public static class EfCoreQueryExtensions
{
	public static List<T> AsEfList<T>(this IReadOnlyCollection<T> collection)
	{
		if (collection is List<T> list) // Most common case, no memory allocation
		{
			return list;
		}

		if (collection.Count == 0) // No memory allocation, because we can
		{
			return EmptyListHolder<T>.EmptyList;
		}

		return collection.ToList();
	}

	private static class EmptyListHolder<T>
	{
		public static readonly List<T> EmptyList = new List<T>();
	}
}
