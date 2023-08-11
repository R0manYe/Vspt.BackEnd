using System.Collections.Generic;


namespace Vspt.Service.Common.Validation.Models;

public sealed class ValidatedData<TRequestItem, TModel>
{
	public IReadOnlyList<TRequestItem> ValidatedItems { get; set; }

	public IReadOnlyList<TRequestItem> InvalidItems { get; set; }

	public IReadOnlyList<TModel> ItemsForInsert { get; set; } = new List<TModel>();

	public IReadOnlyList<TModel> ItemsForUpdate { get; set; } = new List<TModel>();


}
