using Forpost.Common;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return product.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Product>;