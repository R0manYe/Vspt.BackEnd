using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Service.Common.MassTransit.Extensions;

public static class ModelBuilderExtensions
{
	public static void AddTransactionalOutbox(this ModelBuilder modelBuilder)
	{
		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();
	}
}
