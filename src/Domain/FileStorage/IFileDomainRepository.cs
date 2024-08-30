using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.FileStorage;

public interface IFileDomainRepository : IDomainRepository<File>
{
    public Task<IReadOnlyList<File>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken);
}