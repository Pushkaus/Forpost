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
        var repsonse = _mapper.Map<IReadOnlyList<StorageProductModel>>(storageProducts);
        return repsonse;
    }
}