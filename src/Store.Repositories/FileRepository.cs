using AutoMapper;
using Forpost.Domain.FileStorage;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Store.Repositories;

internal sealed class FileRepository : Repository<File>, IFileRepository
{
    public FileRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<File>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ParentId == id).ToListAsync();
    }
}