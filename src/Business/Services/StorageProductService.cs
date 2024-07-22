using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.StorageProduct;
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
    public async Task Add(StorageProductCreateModel model)
    {
        var storageProduct = _mapper.Map<StorageProduct>(model);
        await _storageProductRepository.AddAsync(storageProduct);
    }

    public async Task<IReadOnlyList<StorageProductModel>> GetAllProducts(Guid id)
    {
        var storageProducts = await _storageProductRepository.GetAllById(id);
        var response = _mapper.Map<IReadOnlyList<StorageProductModel>>(storageProducts);
        return response;
    }

    public async Task<StorageProduct?> GetById(Guid id)
    {
        return await _storageProductRepository.GetById(id);
    }

    public async Task Update(StorageProductCreateModel model)
    {
        var storageProduct = _mapper.Map<StorageProduct>(model);
        await _storageProductRepository.UpdateAsync(storageProduct);
    }

    public async Task WriteOff(Guid productId, int quantity)
    {
        var storageProduct = await _storageProductRepository.GetById(productId);
        if (storageProduct != null) storageProduct.Quantity = storageProduct.Quantity - quantity;
        if (storageProduct != null) await _storageProductRepository.UpdateAsync(storageProduct);
    }
}