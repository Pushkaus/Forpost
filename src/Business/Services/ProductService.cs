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
    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
    { 
        return await _productRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Guid> AddAsync(ProductCreateModel model, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(model);
        return await _productRepository.AddAsync(product, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken);
        return product;
    }

    public async Task UpdateAsync(ProductUpdateModel model, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(model);
        await _productRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteByIdAsync(id, cancellationToken);
    }
}