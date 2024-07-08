using System.Collections;
using Forpost.Business.Models.ProductOperations;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IProductOperationService: IBusinessService
{
    public Task Add(OperationCreateModel model);
    public Task<IReadOnlyList<ProductOperation>> GetAll();
    public Task<IReadOnlyList<ProductOperation>> GetAllByProductId(Guid id);
}