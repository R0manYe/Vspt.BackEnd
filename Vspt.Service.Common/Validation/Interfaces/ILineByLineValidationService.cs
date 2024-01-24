using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Vspt.Service.Common.Validation.Models;

namespace Vspt.Service.Common.Validation.Interfaces;

public interface ILineByLineValidationService<TItem>
{
    Task<LineByLineValidationResult<TItem>> Validate<TValidationData>(
        IReadOnlyList<TItem> requestItems,
        TValidationData data,
        CancellationToken cancellationToken
    );

 
}
