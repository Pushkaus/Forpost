using Forpost.Business.Models.TechCards;
using Forpost.Store.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface ITechCardService: IBusinessService
{
    public Task<Guid> AddAsync(TechCardCreateModel model, CancellationToken cancellationToken);
    public Task<TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<TechCard>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}