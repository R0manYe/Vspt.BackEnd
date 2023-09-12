using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed class GetActiveUsersResponseItemDto
{
	public Guid Id { get; set; }

	public string Email { get; set; }
}
