using System;

namespace Vspt.Box.Data.Entities;

public sealed class AuditData
{
	public DateTime CreatedDate { get; set; }
	public Guid CreatedBy { get; set; }
	public DateTime? UpdatedDate { get; set; }
	public Guid? UpdatedBy { get; set; }
}
