using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record SearchUsersRequestDto
{
	public int Skip { get; init; }

	public int Take { get; init; }

	public string Keyword { get; init; }

	public DateTime? LastLoginBefore { get; init; }
}
