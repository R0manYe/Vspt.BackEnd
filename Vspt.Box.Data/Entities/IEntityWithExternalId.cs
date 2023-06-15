namespace Vspt.Box.Data.Entities;

public interface IEntityWithExternalId : IEntity
{
	public string ExternalId { get; set; }
}
