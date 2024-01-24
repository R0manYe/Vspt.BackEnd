using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record UserRoleDto
{
	public required Guid Id { get; init; }

	public required string Name { get; init; }

	public required string Code { get; init; }
}
