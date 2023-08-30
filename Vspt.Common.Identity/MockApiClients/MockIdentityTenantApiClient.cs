using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Vspt.Common.Identity.ApiClients;

namespace Vspt.Common.Identity.MockApiClients;

internal sealed class MockIdentityTenantApiClient : IIdentityTenantApiClient
{
	/*public Task<Guid> Create(CreateTenantRequestDto request, CancellationToken cancelationToken)
	{
		return Task.FromResult(Guid.NewGuid());
	}

	public Task<GetTenantResponseDto> GetById(Guid id, CancellationToken cancelationToken)
	{
		return Task.FromResult(_tenants.FirstOrDefault(x => x.Id == id));
	}

	public Task Update(UpdateTenantRequestDto request, CancellationToken cancelationToken)
	{
		throw new NotImplementedException();
	}

	public Task Delete(Guid id, CancellationToken cancelationToken)
	{
		throw new NotImplementedException();
	}

	private static readonly List<GetTenantResponseDto> _tenants = new List<GetTenantResponseDto>
	{
		new GetTenantResponseDto { Id = Guid.Parse("a23193d6-2d30-40a7-9fc0-8ca2646f6f35"), Name = "1" }
	};*/
}
