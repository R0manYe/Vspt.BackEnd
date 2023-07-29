using FluentValidation;
using Tiss.Common.Api.Contracts.Pagination;

namespace Vspt.Common.Api.Contract.Pagination.Validators;

public sealed class PagingValidator : AbstractValidator<IPaging>
{
    public PagingValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000);
    }
}
