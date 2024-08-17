using Forpost.Common.EntityAnnotations;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly ForpostContextPostgres _db;
    protected readonly DbSet<TEntity> DbSet;
    
    public Repository(ForpostContextPostgres db)
    {
        _db = db;
        DbSet = db.Set<TEntity>();
    }
    public async Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _db.AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        var id = entity.Id;
        return id;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Update(entity);
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FirstAsync(entity => entity.Id == id, cancellationToken);
        _db.Entry(entity).State = EntityState.Deleted;
        await _db.SaveChangesAsync(cancellationToken);
    }
}