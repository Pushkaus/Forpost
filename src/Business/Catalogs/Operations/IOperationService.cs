using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Operations;

public interface IOperationService: IBusinessService
{
    public Task<Guid> AddAsync(Operation model, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<OperationEntity>> GetAllAsync (CancellationToken cancellationToken);
}