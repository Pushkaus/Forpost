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

    public async Task<(IReadOnlyList<TEntity> Items, int TotalCount)> GetAllAsync(
        string? filterExpression,
        object?[]? filterValues,
        CancellationToken cancellationToken,
        int skip = 0,
        int limit = 100)
    {
        IQueryable<TEntity> query = DbSet;
        
        if (typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
        {
            query = query.Where(e => ((IAuditableEntity)e).DeletedAt == null);
        }
        
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
    
        var items = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
        
        return (items, totalCount);
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