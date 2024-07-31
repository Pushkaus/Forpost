using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
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