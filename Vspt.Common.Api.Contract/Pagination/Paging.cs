namespace Vspt.Common.Api.Contracts.Pagination;

public sealed record Paging : IPaging
{
	public required int Page { get; init; }

	public required int Size { get; init; }
}
