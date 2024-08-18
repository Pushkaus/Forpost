using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IFilesRepository : IRepository<FileEntity>
{
    public Task<IReadOnlyList<FileEntity>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken);
}