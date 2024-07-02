using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.ProductOperation;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IProductOperationRepository
{
    public Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description, decimal? operationTime,
        decimal? cost);

    public Task<IEnumerable<GerProductOperations>> GetAllOperationOnProduct(string productName);
}