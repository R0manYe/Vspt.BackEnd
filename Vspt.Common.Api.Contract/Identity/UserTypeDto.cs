namespace Vspt.Common.Api.Contracts.Identity;

public sealed record UserTypeDto
{
	public required byte Id { get; init; }

	public required string Name { get; init; }

	public string Code { get; init; }
}
