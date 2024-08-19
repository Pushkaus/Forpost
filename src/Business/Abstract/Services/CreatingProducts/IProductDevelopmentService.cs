using Forpost.Business.Models.ProductDevelopment;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface IProductDevelopmentService: IBusinessService
{
    public Task<Guid> AddAsync(ProductDevelopmentCreateModel model, CancellationToken cancellationToken);
    public Task<ProductDevelopment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<ProductDevelopment>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}