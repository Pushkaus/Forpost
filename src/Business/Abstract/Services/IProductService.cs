using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IProductService: IBusinessService
{
    public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> AddAsync(ProductCreateModel model, CancellationToken cancellationToken);
    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task UpdateAsync(ProductUpdateModel model, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
}