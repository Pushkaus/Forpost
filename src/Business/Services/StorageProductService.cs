using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.StorageProduct;
using Forpost.Common;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class StorageProductService: IStorageProductService
{
    private readonly IStorageProductRepository _storageProductRepository;
    private readonly IMapper _mapper;
    public StorageProductService(IStorageProductRepository storageProductRepository, IMapper mapper)
    {
        _storageProductRepository = storageProductRepository;
        _mapper = mapper;
    }
    public async Task<Guid> AddAsync(StorageProductCreateModel model, CancellationToken cancellationToken)
    {
        var storageProduct = _mapper.Map<StorageProduct>(model);
        return await _storageProductRepository.AddAsync(storageProduct, cancellationToken);
    }

    public async Task<IReadOnlyList<StorageProductModel>> 
        GetAllProductsAsync(Guid id, CancellationToken cancellationToken)
    {
        var storageProducts = await _storageProductRepository.GetAllByStorageIdAsync(id, cancellationToken);
        var response = _mapper.Map<IReadOnlyList<StorageProductModel>>(storageProducts);
        return response;
    }

    public async Task<StorageProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _storageProductRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(StorageProductCreateModel model, CancellationToken cancellationToken)
    {
        var storageProduct = _mapper.Map<StorageProduct>(model);
        await _storageProductRepository.UpdateAsync(storageProduct, cancellationToken);
    }

    public async Task WriteOffAsync(Guid productId, int quantity, CancellationToken cancellationToken)
    {
        var storageProduct = await _storageProductRepository.GetByIdAsync(productId, cancellationToken);
        
        storageProduct.EnsureFoundBy(x=>x.Id, productId);
        storageProduct.Quantity -= quantity;
        
        await _storageProductRepository.UpdateAsync(storageProduct, cancellationToken);
    }
}