using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IProductService: IBusinessService
{
    public Task<IReadOnlyList<Product>> GetAll();
    public Task Add(ProductCreateModel model);
    public Task<Product?> GetById(Guid id);
    public Task Update(ProductUpdateModel model);
    public Task Delete(Guid id);
    
}