// using AutoMapper;
// using Forpost.Common;
// using Forpost.EventBus;
// using Forpost.Store.Entities;
// using Forpost.Store.Repositories.Abstract;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
//
// namespace Forpost.Business.SortOut;
//
// internal sealed class StorageProductService : BusinessService, IStorageProductService
// {
//     public StorageProductService(
//         IDbUnitOfWork dbUnitOfWork,
//         ILogger<BusinessService> logger,
//         IMapper mapper,
//         IConfiguration configuration,
//         IDomainEventBus domainEventBus,
//         TimeProvider timeProvider
//     )
//         : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
//     {
//     }
//
//     public async Task<Guid> AddAsync(StorageProductCreateCommand model, CancellationToken cancellationToken)
//     {
//         var storageProduct = Mapper.Map<StorageProductEntity>(model);
//         var storageProductId = DbUnitOfWork.StorageProductRepository.Add(storageProduct);
//         await DbUnitOfWork.SaveChangesAsync(cancellationToken);
//         return storageProductId;
//     }
//
//     public async Task<IReadOnlyList<StorageProduct>>
//         GetAllProductsAsync(Guid id, CancellationToken cancellationToken)
//     {
//         var storageProducts = await DbUnitOfWork.StorageProductRepository.GetAllByStorageIdAsync(id, cancellationToken);
//         var response = Mapper.Map<IReadOnlyList<StorageProduct>>(storageProducts);
//         return response;
//     }
//
//     public async Task<StorageProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
//     {
//         return await DbUnitOfWork.StorageProductRepository.GetByIdAsync(id, cancellationToken);
//     }
//
//     public async Task UpdateAsync(StorageProductCreateCommand model, CancellationToken cancellationToken)
//     {
//         var storageProduct = Mapper.Map<StorageProductEntity>(model);
//         DbUnitOfWork.StorageProductRepository.Update(storageProduct);
//         await DbUnitOfWork.SaveChangesAsync(cancellationToken);
//     }
//
//     public async Task WriteOffAsync(Guid productId, int quantity, CancellationToken cancellationToken)
//     {
//         var storageProduct = await DbUnitOfWork.StorageProductRepository.GetByIdAsync(productId, cancellationToken);
//
//         storageProduct.EnsureFoundBy(x => x.Id, productId);
//         storageProduct!.Quantity -= quantity;
//
//         DbUnitOfWork.StorageProductRepository.Update(storageProduct);
//         await DbUnitOfWork.SaveChangesAsync(cancellationToken);
//     }
// }