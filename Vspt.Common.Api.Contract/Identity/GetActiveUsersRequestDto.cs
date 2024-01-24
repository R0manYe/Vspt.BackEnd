using System.Collections.Generic;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record GetActiveUsersRequestDto
{
	public required List<string> Emails { get; init; }
}
