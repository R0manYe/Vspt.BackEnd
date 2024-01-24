using System;

namespace Vspt.Service.Common.Infrastructure.Repository;

internal sealed class UniqueIdentifierProvider : IUniqueIdentifierProvider
{
	public Guid GetNewId()
	{
		return Guid.NewGuid();
	}
}
