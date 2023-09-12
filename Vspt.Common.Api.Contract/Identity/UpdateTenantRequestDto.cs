using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record UpdateTenantRequestDto
{
	public required Guid Id { get; init; }
	public required string Name { get; init; }
}
