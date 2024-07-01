using Forpost.Business.Abstract.Services;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public class SubProductService: ISubProductService
{
    private readonly ISubProductRepository _subProductRepository;

    public SubProductService(ISubProductRepository subProductRepository)
    {
        _subProductRepository = subProductRepository;
    }
    public async Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity)
    {
       var result = await _subProductRepository.AddSubProduct(parentName, daughterName, unitOfMeasure, quantity);
       return result;
    }
}