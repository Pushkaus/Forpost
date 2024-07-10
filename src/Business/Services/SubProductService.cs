using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.SubProducts;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public class SubProductService: ISubProductService
{
    private readonly ISubProductRepository _subProductRepository;
    private readonly IMapper _mapper;
    public SubProductService(ISubProductRepository subProductRepository, IMapper mapper)
    {
        _subProductRepository = subProductRepository;
        _mapper = mapper;
    }
    public async Task Add(SubProductCreateModel model)
    {
        var subProduct = _mapper.Map<SubProduct>(model);
        await _subProductRepository.AddAsync(subProduct);
    }

    public async Task<IReadOnlyList<SubProductModel?>> GetAllProducts(Guid id)
    {
        var subProducts = await _subProductRepository.GetAllById(id);
        var response = _mapper.Map<IReadOnlyList<SubProductModel>>(subProducts);
        return response;
    }
}