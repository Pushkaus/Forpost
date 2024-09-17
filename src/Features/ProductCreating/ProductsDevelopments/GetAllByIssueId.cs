using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllByIssueIdQueryHandler: 
    IQueryHandler<GetAllByIssueIdQuery, IReadOnlyCollection<ProductDevelopmentDetails>>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetAllByIssueIdQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ProductDevelopmentDetails>>
        Handle(GetAllByIssueIdQuery query, CancellationToken cancellationToken) =>
        await _productDevelopmentReadRepository.GetAllByIssueId(query.IssueId, cancellationToken);
}
public record GetAllByIssueIdQuery(Guid IssueId): IQuery<IReadOnlyCollection<ProductDevelopmentDetails>>;