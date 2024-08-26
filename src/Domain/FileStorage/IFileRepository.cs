using Forpost.Common.DataAccess;

namespace Forpost.Domain.FileStorage;

public interface IFileRepository : IRepository<File>
{
    public Task<IReadOnlyList<File>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken);
}