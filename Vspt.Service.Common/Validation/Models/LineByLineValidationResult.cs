using System.Collections.Generic;


namespace Vspt.Service.Common.Validation.Models;

public sealed record LineByLineValidationResult<TItem>
{
    public required IReadOnlyList<TItem> ValidItems { get; init; }

    public required IReadOnlyList<TItem> InvalidItems { get; init; }

   
}
