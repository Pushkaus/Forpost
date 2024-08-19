using Forpost.Business.Models.ManufacturingProcesses;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface IManufacturingProcessService: IBusinessService
{
    public Task<Guid> AddAsync(ManufacturingProcessCreateModel model, CancellationToken cancellationToken);
    public Task<ManufacturingProcess?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<ManufacturingProcess>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}