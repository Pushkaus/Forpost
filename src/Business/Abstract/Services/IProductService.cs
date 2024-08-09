using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IProductService: IBusinessService
{
    public Task<IReadOnlyList<Product>> GetAll();
    public Task<Guid> Add(ProductCreateModel model);
    public Task<Product?> GetById(Guid id);
    public Task Update(ProductUpdateModel model);
    public Task Delete(Guid id);
    
}