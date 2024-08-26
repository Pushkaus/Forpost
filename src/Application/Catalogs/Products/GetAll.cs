using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class GetAllProductsQueryHandler :
    IRequestHandler<GetAllProductsQuery, IReadOnlyCollection<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Product>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllProductsQuery : IRequest<IReadOnlyCollection<Product>>;