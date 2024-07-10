using System.Collections;
using Forpost.Business.Models.SubProducts;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface ISubProductService: IBusinessService
{
    public Task Add(SubProductCreateModel model);
    public Task<IReadOnlyList<SubProductModel?>> GetAllProducts(Guid id);
}