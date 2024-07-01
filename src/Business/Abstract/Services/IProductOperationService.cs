using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IProductOperationService: IBusinessService
{
    public Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description, decimal? operationTime,
        decimal? cost);

    public Task<IEnumerable<ProductOperation>> GetAllOperationOnProduct(string productName);
}