using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface ITechCardService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardCreateModel model, CancellationToken cancellationToken);
    public Task<TechCardEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}