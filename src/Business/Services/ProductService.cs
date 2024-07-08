using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public sealed class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IProductOperationRepository _productOperationRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper, IProductOperationRepository productOperationRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _productOperationRepository = productOperationRepository;
    }
    public async Task<IReadOnlyList<Product>> GetAll()
    { 
        return await _productRepository.GetAllAsync();
    }

    public async Task Add(ProductCreateModel model)
    {
        var product = _mapper.Map<Product>(model);
        await _productRepository.AddAsync(product);
    }

    public async Task<Product?> GetById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }

    public async Task Update(ProductUpdateModel model)
    {
        var product = _mapper.Map<Product>(model);
        await _productRepository.UpdateAsync(product);
    }

    public async Task Delete(Guid id)
    {
        await _productRepository.DeleteByIdAsync(id);
    }
}