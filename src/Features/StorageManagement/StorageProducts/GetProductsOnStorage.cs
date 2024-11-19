using Forpost.Application.Contracts.StorageManagement;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.StorageManagment;
using Mediator;

namespace Forpost.Features.StorageManagement.StorageProducts;

internal sealed class GetProductsOnStorageQueryHandler : IQueryHandler<GetProductsOnStorageQuery, (
    IReadOnlyCollection<StorageProductModel> Products, int TotalCount)>
{
    private readonly IStorageProductReadRepository _storageProductReadRepository;

    public GetProductsOnStorageQueryHandler(IStorageProductReadRepository storageProductReadRepository)
    {
        _storageProductReadRepository = storageProductReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<StorageProductModel> Products, int TotalCount)> Handle(
        GetProductsOnStorageQuery query, CancellationToken cancellationToken)
    {
        return await _storageProductReadRepository.GetProductsOnStorage(query.StorageId, query.Skip, query.Limit,
            cancellationToken);
    }
}

public record GetProductsOnStorageQuery(Guid StorageId, int Skip, int Limit)
    : IQuery<(IReadOnlyCollection<StorageProductModel> Products, int TotalCount)>;