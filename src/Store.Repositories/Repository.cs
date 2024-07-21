using Forpost.Common.EntityAnnotations;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly ForpostContextPostgres _db;
    protected readonly DbSet<TEntity> DbSet;
    
    public Repository(ForpostContextPostgres db)
    {
        _db = db;
        DbSet = db.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<TEntity?>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.Where(entity => entity.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await DbSet.FirstAsync(entity => entity.Id == id);
        _db.Entry(entity).State = EntityState.Deleted;
        await _db.SaveChangesAsync();
    }
}