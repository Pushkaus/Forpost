using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.StorageManagement;

public interface IStorageProductReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<StorageProductModel> Products, int TotalCount)> GetProductsOnStorage(
        Guid storageId, int skip,
        int limit, CancellationToken cancellationToken);
    
}