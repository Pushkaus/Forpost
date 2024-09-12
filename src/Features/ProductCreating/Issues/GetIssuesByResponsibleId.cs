using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class GetIssuesByResponsibleIdQueryHandler: 
    IQueryHandler<GetIssuesByResponsibleIdQuery, IReadOnlyCollection<Issue>>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public GetIssuesByResponsibleIdQueryHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Issue>> Handle(GetIssuesByResponsibleIdQuery query, CancellationToken cancellationToken) 
        => await _issueDomainRepository.GetIssuesByResponsibleId(query.ResponsibleId, cancellationToken);
}
public record GetIssuesByResponsibleIdQuery(Guid ResponsibleId): IQuery<IReadOnlyCollection<Issue>>;