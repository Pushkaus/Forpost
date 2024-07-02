using System.Collections;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.ProductOperation;

namespace Forpost.Business.Services;

public sealed class ProductOperationService: IProductOperationService
{
    private readonly IProductOperationRepository _productOperationRepository;

    public ProductOperationService(IProductOperationRepository productOperationRepository)
    {
        _productOperationRepository = productOperationRepository;
    }
    public async Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description,
        decimal? operationTime,
        decimal? cost)
    {
        var result = await _productOperationRepository.AddOperationAsync(userId, productName, name, description, operationTime, cost);
        return result;
    }

    public async Task<IEnumerable<GerProductOperations>> GetAllOperationOnProduct(string productName)
    {
        var result = await _productOperationRepository.GetAllOperationOnProduct(productName);
        return result;
    }
}