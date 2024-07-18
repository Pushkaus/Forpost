using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class FileRepository: Repository<FileEntity>, IFilesRepository
{
    public FileRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<FileEntity?>> GetAllById(Guid id)
    {
        return await DbSet.Where(entity => entity.ParentId == id).ToListAsync();
    }
}