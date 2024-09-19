using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllByIssueIdQueryHandler: 
    IQueryHandler<GetAllByIssueIdQuery, (IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetAllByIssueIdQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
        Handle(GetAllByIssueIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _productDevelopmentReadRepository.GetAllByIssueId(query.IssueId, cancellationToken, query.Skip,
            query.Limit);
        return (result.ProductDevelopments, result.TotalCount);
    }
}
public record GetAllByIssueIdQuery(Guid IssueId, int Skip, int Limit): 
    IQuery<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>;