using System;

namespace Vspt.Box.Data.Entities;

public interface IEntityWithId : IEntity
{
	Guid Id { get; set; }
}
