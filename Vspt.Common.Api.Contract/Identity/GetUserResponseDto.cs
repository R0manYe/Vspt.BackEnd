using System;
using System.Collections.Generic;

namespace Vspt.Common.Api.Contracts.Identity;

public sealed record GetUserResponseDto
{
	public Guid Id { get; init; }
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public string MiddleName { get; init; }
	public string Login { get; init; }
	public string Email { get; init; }
	public string PhoneNumber { get; init; }
	public bool IsBlocked { get; init; }
	public DateTime? BlockedDate { get; init; }
	public bool IsAdmin { get; init; }
	public string StatusName { get; init; }
	public UserTypeDto Type { get; init; }
	public IReadOnlyList<UserRoleDto> Roles { get; init; }
	public IReadOnlyList<UserTenantDto> Tenants { get; init; }
}
