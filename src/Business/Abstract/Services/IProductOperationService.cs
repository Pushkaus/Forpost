using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.ProductOperation;

namespace Forpost.Business.Abstract.Services;

public interface IProductOperationService: IBusinessService
{
    public Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description, decimal? operationTime,
        decimal? cost);

    public Task<IEnumerable<GerProductOperations>> GetAllOperationOnProduct(string productName);
}