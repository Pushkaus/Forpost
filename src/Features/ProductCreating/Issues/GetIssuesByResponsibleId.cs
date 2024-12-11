using Forpost.Application.Contracts.ProductCreating.Issues;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetIssuesByResponsibleIdQueryHandler: 
    IQueryHandler<GetIssuesByResponsibleIdQuery, (IReadOnlyCollection<IssueModel> Issues, int TotalCount)>
{
    private readonly IIssueReadRepository _issueReadRepository;

    public GetIssuesByResponsibleIdQueryHandler(IIssueReadRepository issueDomainRepository)
    {
        _issueReadRepository = issueDomainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)>
        Handle(GetIssuesByResponsibleIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _issueReadRepository
            .GetIssuesByResponsibleId(query.ResponsibleId, cancellationToken, query.Skip, query.Limit);
        return (result.Issues, result.TotalCount);
    }
}
public record GetIssuesByResponsibleIdQuery(Guid ResponsibleId, int Skip, int Limit):
    IQuery<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)>;