using System.Collections.Generic;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record GetAvailableUsersResponseDto
{
	public IReadOnlyList<GetUserResponseDto> Items { get; init; }
}
