using System;
using System.Collections.Generic;

namespace Vspt.Common.Api.Contracts.Identity;

public record CreateUserRequestDto
{
	public string Login { get; init; }
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public string MiddleName { get; init; }
	public string Email { get; init; }
	public bool EmailConfirmed { get; init; }
	public string PhoneNumber { get; set; }
	public bool PhoneNumberConfirmed { get; init; }
	public byte? UserTypeId { get; init; }
	public bool IsAgreementAcceptanceRequired { get; init; }
	public bool IsResetPasswordLinkSendingRequired { get; init; }
	public ICollection<Guid> RoleIds { get; init; }
	public ICollection<Guid> TenantIds { get; init; }
}
