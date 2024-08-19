using AutoMapper;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.Models.CompletedProduct;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class CompletedProductService: ICompletedProductService
{
    private readonly ICompletedProductRepository _completedProductRepository;

    private readonly IMapper _mapper;

    public CompletedProductService(ICompletedProductRepository completedProductRepository, IMapper mapper)
    {
        _completedProductRepository = completedProductRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CompletedProductCreateModel model, CancellationToken cancellationToken)
    {
        var completeProduct = _mapper.Map<CompletedProduct>(model);
        return await _completedProductRepository.AddAsync(completeProduct, cancellationToken);
    }

    public async Task<CompletedProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _completedProductRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IReadOnlyList<CompletedProduct>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _completedProductRepository.GetAllAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _completedProductRepository.DeleteByIdAsync(id, cancellationToken);
    }
}