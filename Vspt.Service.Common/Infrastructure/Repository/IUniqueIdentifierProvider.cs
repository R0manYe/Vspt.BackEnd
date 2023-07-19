using System;

namespace Vspt.Service.Common.Infrastructure.Repository;

public interface IUniqueIdentifierProvider
{
	Guid GetNewId();
}
