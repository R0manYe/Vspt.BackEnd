namespace Vspt.Common.Api.Contracts.Identity;

public sealed record CreateTenantRequestDto
{
	public required string Name { get; init; }
}
