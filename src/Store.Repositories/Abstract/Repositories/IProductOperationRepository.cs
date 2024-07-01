using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IProductOperationRepository
{
    public Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description, decimal? operationTime,
        decimal? cost);

    public Task<IEnumerable<ProductOperation>> GetAllOperationOnProduct(string productName);
}