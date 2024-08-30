using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class GetAllQueryHandler: IRequestHandler<GetAllQuery, IReadOnlyCollection<ProductDevelopment>>
{
    private readonly IProductDevelopmentRepository _productDevelopmentRepository;

    public GetAllQueryHandler(IProductDevelopmentRepository productDevelopmentRepository)
    {
        _productDevelopmentRepository = productDevelopmentRepository;
    }

    public async Task<IReadOnlyCollection<ProductDevelopment>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _productDevelopmentRepository.GetAllAsync(cancellationToken);
    }
}
public record GetAllQuery(): IRequest<IReadOnlyCollection<ProductDevelopment>>;