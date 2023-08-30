using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Refit;
//ispt.Common.Api.Contracts.Identity;
using Vspt.Common.Identity.ApiClients;

namespace Vspt.Common.Identity.MockApiClients;

internal sealed class MockIdentityUserApiClient : IIdentityUserApiClient
{
	/*public Task<GetUserResponseDto> GetById(Guid id, CancellationToken cancelationToken)
	{
		return Task.FromResult(_users.FirstOrDefault(x => x.Id == id));
	}

	public Task<Guid> Create(CreateUserRequestDto request, CancellationToken cancelationToken)
	{
		return Task.FromResult(Guid.NewGuid());
	}

	public Task Update(UpdateUserRequestDto request, CancellationToken cancelationToken)
	{
		throw new NotImplementedException();
	}

	public Task Block(Guid id, CancellationToken cancelationToken)
	{
		return Task.CompletedTask;
	}

	public Task BlockRange(List<Guid> ids, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	public Task Unblock(Guid id, CancellationToken cancelationToken)
	{
		return Task.CompletedTask;
	}

	public Task UnblockRange(List<Guid> ids, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	public Task Approve(Guid id, CancellationToken cancelationToken)
	{
		return Task.CompletedTask;
	}

	public Task Delete(Guid id, CancellationToken cancelationToken)
	{
		throw new NotImplementedException();
	}

	public Task<List<GetActiveUsersResponseItemDto>> GetActiveUsers([Body] GetActiveUsersRequestDto request, CancellationToken cancellationToken)
	{
		return Task.FromResult(new List<GetActiveUsersResponseItemDto>());
	}

	public Task<GetAvailableUsersResponseDto> Search([Body] SearchUsersRequestDto request, CancellationToken cancellationToken)
	{
		var users = new List<GetUserResponseDto>();

		if (!string.IsNullOrWhiteSpace(request.Keyword))
		{
			users = _users.Where(x =>
				string.Concat(x.LastName.ToLower(CultureInfo.CurrentCulture), " ", x.FirstName.ToLower(CultureInfo.CurrentCulture), " ", x.MiddleName.ToLower(CultureInfo.CurrentCulture)).Contains(request.Keyword)
				|| x.Email.Contains(request.Keyword)
				|| x.PhoneNumber.Contains(request.Keyword)
			).ToList();
		}

		return Task.FromResult(new GetAvailableUsersResponseDto { Items = users });
	}

	// TODO: store user data
	private static readonly List<GetUserResponseDto> _users = new List<GetUserResponseDto>
	{
		new GetUserResponseDto
		{
			Id = Guid.Parse("e985d53d-9428-449e-8d19-a15ee1344fab"),
			FirstName = "test",
			LastName = "test",
			MiddleName = "test",
			Email = "test@test.com",
			Login = "test@test.com",
			IsAdmin = false,
			PhoneNumber = "1234567890",
			IsBlocked = false,
			Roles = new List<UserRoleDto>
			{
				new UserRoleDto{ Code="code", Id = Guid.NewGuid(), Name = "Role1" },
				new UserRoleDto{ Code="code", Id = Guid.NewGuid(), Name = "Role2" }
			},
			Tenants = new List<UserTenantDto>{ },
			StatusName = "Active",
			Type = new UserTypeDto{ Code = "code", Id = 1, Name = "type" }
		},
		new GetUserResponseDto
		{
			Id = Guid.Parse("e345d53d-9428-449e-8d19-a15ee1344fab"),
			FirstName = "test2",
			LastName = "test2",
			MiddleName = "test2",
			Email = "test2@test.com",
			Login = "test2@test.com",
			IsAdmin = false,
			PhoneNumber = "1234567890",
			IsBlocked = false,
			Roles = new List<UserRoleDto>{ },
			Tenants = new List<UserTenantDto>{ },
			StatusName = "Active",
			Type = new UserTypeDto{ Code = "code", Id = 1, Name = "type" }
		}
	};*/
}
