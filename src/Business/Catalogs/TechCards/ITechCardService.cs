using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.TechCards;

public interface ITechCardService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardCreateCommand model, CancellationToken cancellationToken);
    public Task<TechCardEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCardEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}