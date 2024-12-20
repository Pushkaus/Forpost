using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using AutoMapper;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EntityAnnotations;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal abstract class DomainRepository<TEntity> : IDomainRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly IMapper Mapper;
    protected readonly ForpostContextPostgres DbContext;
    protected readonly DbSet<TEntity> DbSet;
    protected readonly TimeProvider TimeProvider;

    protected DomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
    {
        DbContext = dbContext;
        TimeProvider = timeProvider;
        Mapper = mapper;
        DbSet = dbContext.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        IQueryable<TEntity> query = DbSet;

        if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
        {
            query = query.Where(e => ((IAuditableEntity)e).DeletedAt == null);
        }

        var items = await query.ToListAsync(cancellationToken);

        return items;
    }


    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await DbSet.ById(id).FirstOrDefaultAsync(cancellationToken);

    public Guid Add(TEntity entity)
    {
        DbSet.Entry(entity).State = EntityState.Added;
        return entity.Id;
    }

    public void Update(TEntity entity) => DbContext.Entry(entity).State = EntityState.Modified;

    public void DeleteById(Guid id) => DbContext.Entry(DbSet.ById(id).First()).State = EntityState.Deleted;
}