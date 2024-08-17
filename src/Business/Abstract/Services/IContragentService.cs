using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IContragentService: IBusinessService
{
    public Task AddAsync(string name, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Contragent>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Contragent?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}