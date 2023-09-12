using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record UserTenantDto
{
	public required Guid Id { get; init; }

	public string Name { get; init; }
}
