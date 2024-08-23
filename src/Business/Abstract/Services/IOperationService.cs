using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IOperationService: IBusinessService
{
    public Task<Guid> AddAsync(OperationModel model, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Operation>> GetAllAsync (CancellationToken cancellationToken);
}