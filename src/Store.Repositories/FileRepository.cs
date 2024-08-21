using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class FileRepository : Repository<FileEntity>, IFilesRepository
{
    public FileRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<FileEntity>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ParentId == id).ToListAsync();
    }
}