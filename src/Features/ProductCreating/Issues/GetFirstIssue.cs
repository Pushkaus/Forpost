using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetFirstIssueQueryHandler: IQueryHandler<GetFirstIssueQuery, Guid>
{
    public ValueTask<Guid> Handle(GetFirstIssueQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public record GetFirstIssueQuery(Guid ManufacturingProcessId): IQuery<Guid>;