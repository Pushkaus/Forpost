using AutoMapper;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.Models.ProductDevelopment;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class ProductDevelopmentService: IProductDevelopmentService
{
    private readonly IProductDevelopmentRepository _productDevelopmentRepository;
    private readonly IMapper _mapper;

    public ProductDevelopmentService(IMapper mapper, IProductDevelopmentRepository productDevelopmentRepository)
    {
        _mapper = mapper;
        _productDevelopmentRepository = productDevelopmentRepository;
    }

    public async Task<Guid> AddAsync(ProductDevelopmentCreateModel model, CancellationToken cancellationToken)
    {
        var productDevelopment = _mapper.Map<ProductDevelopment>(model);
        return await _productDevelopmentRepository.AddAsync(productDevelopment, cancellationToken);
    }

    public async Task<ProductDevelopment?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _productDevelopmentRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<ProductDevelopment>> GetAllAsync(CancellationToken cancellationToken) 
        => await _productDevelopmentRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _productDevelopmentRepository.DeleteByIdAsync(id, cancellationToken);
}