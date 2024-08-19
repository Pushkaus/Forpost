using Forpost.Business.Models.Issues;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface IIssueService: IBusinessService
{
    public Task<Guid> AddAsync(IssueCreateModel model, CancellationToken cancellationToken);
    public Task<Issue?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Issue>> GetAllAsync(CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}