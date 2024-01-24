namespace Vspt.Box.Data.Entities;

public interface IEntityWithAuditData : IEntity
{
	AuditData AuditData { get; set; }
}
