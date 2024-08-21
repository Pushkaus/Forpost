using AutoMapper;
using Forpost.Common.EntityAnnotations;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly IMapper Mapper;
    protected readonly ForpostContextPostgres DbContext;
    protected readonly DbSet<TEntity> DbSet;
    protected readonly TimeProvider TimeProvider;

    protected Repository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
    {
        DbContext = dbContext;
        TimeProvider = timeProvider;
        Mapper = mapper;
        DbSet = dbContext.Set<TEntity>();
    }

    public async Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbContext.AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        var id = entity.Id;
        return id;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.ById(id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Update(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.ById(id).FirstAsync(cancellationToken);
        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}