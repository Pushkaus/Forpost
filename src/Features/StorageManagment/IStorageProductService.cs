// using Forpost.Business;
// using Forpost.Business.SortOut;
// using Forpost.Domain.SortOut;
//
// namespace Forpost.Featuresc interface IStorageProductService : IBusinessService
// {
//     public Task<Guid> AddAsync(StorageProductCreateCommand model, CancellationToken cancellationToken);
//     public Task<IReadOnlyList<StorageProduct>> GetAllProductsAsync(Guid id, CancellationToken cancellationToken);
//     public Task<StorageProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
//     public Task UpdateAsync(StorageProductCreateCommand model, CancellationToken cancellationToken);
//     public Task WriteOffAsync(Guid productId, int quantity, CancellationToken cancellationToken);
// }