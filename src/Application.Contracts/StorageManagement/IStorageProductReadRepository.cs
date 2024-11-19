using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.Products;

namespace Forpost.Application.Contracts.StorageManagement;

public interface IStorageProductReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<StorageProductModel> Products, int TotalCount)> GetProductsOnStorage(
        Guid storageId, int skip,
        int limit, CancellationToken cancellationToken);
    
}