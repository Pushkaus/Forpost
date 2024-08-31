using Forpost.Application.Contracts;
using Forpost.Common.Extensions;
using Forpost.Common.Utils;
using Forpost.Domain.Primitives.EntityAnnotations;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Forpost.Store.Repositories;

internal sealed class DbUnitOfWork : IDbUnitOfWork
{
    private readonly ForpostContextPostgres _dbContext;
    private readonly IIdentityProvider _identityProvider;
    private readonly TimeProvider _timeProvider;

    public DbUnitOfWork(ForpostContextPostgres dbContext,
        IIdentityProvider identityProvider, 
        TimeProvider timeProvider)
    {
        _dbContext = dbContext;
        _identityProvider = identityProvider;
        _timeProvider = timeProvider;
    }

    public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditableEntries = _dbContext.ChangeTracker.Entries<IAuditableEntity>().ToArray();

        if (auditableEntries.IsNotEmpty())
            MarkAuditEntities(auditableEntries);
        
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void MarkAuditEntities(EntityEntry<IAuditableEntity>[] auditableEntries)
    {
        var userId = _identityProvider.GetUserId() ?? Guid.Empty;
                    // throw new InvalidOperationException("Пользователь, модифицирующий сущности обязан быть авторизованным");

        foreach (var entry in auditableEntries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(e => e.CreatedAt).CurrentValue = _timeProvider.GetUtcNow();
                    entry.Property(e => e.CreatedById).CurrentValue = userId;
                    entry.Property(e => e.UpdatedAt).CurrentValue = _timeProvider.GetUtcNow();
                    entry.Property(e => e.UpdatedById).CurrentValue = userId;
                    break;
                case EntityState.Modified:
                    entry.Property(e => e.UpdatedAt).CurrentValue = _timeProvider.GetUtcNow();
                    entry.Property(e => e.UpdatedById).CurrentValue = userId;
                    break;
                case EntityState.Deleted:
                    entry.Property(e => e.DeletedAt).CurrentValue = _timeProvider.GetUtcNow();
                    entry.Property(e => e.DeletedById).CurrentValue = userId;
                    entry.State = EntityState.Modified;
                    break;
            }
    }
}