using System;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record UpdateUserRequestDto : CreateUserRequestDto
{
	public Guid Id { get; init; }
}
