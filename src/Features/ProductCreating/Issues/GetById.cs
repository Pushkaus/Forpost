using Forpost.Application.Contracts.ProductCreating.Issues;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetByIdQueryHandler: IQueryHandler<GetByIdQuery, IssueModel?>
{
    private readonly IIssueReadRepository _issueReadRepository;

    public GetByIdQueryHandler(IIssueReadRepository issueReadRepository)
    {
        _issueReadRepository = issueReadRepository;
    }

    public async ValueTask<IssueModel?> Handle(GetByIdQuery query, CancellationToken cancellationToken) 
        => await _issueReadRepository.GetById(query.IssueId, cancellationToken);
}
public record GetByIdQuery(Guid IssueId): IQuery<IssueModel>;