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
    
    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken) => 
        await DbSet.ToListAsync(cancellationToken);

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => 
        await DbSet.ById(id).FirstOrDefaultAsync(cancellationToken);

    public Guid Add(TEntity entity)
    {
        entity.Id = Guid.NewGuid();
        DbSet.Entry(entity).State = EntityState.Added;
        return entity.Id;
    }

    public void Update(TEntity entity) => DbContext.Entry(entity).State = EntityState.Modified;

    public void DeleteById(Guid id) => DbContext.Entry(DbSet.ById(id).First()).State = EntityState.Deleted;
}