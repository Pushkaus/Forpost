using System.Reflection;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EntityTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Forpost.Store.Postgres.Interceptors;

public sealed class ChangeHistoryInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<Type, string[]> ChangeLoggingEntities =
        new()
        {
            [typeof(Invoice)] =
            [
                nameof(Invoice.InvoiceStatus), nameof(Invoice.Priority),
                nameof(Invoice.PaymentStatus), nameof(Invoice.PaymentPercentage)
            ]
        };

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var changeHistory = dbContext.ChangeTracker.Entries<DomainAuditableEntity>()
            .Where(x => x.State is EntityState.Added or EntityState.Modified)
            .Where(e => ChangeLoggingEntities.ContainsKey(e.Entity.GetType()))
            .ToList();

        foreach (var entry in changeHistory)
        {
            var trackingPropertyNames =
                ChangeLoggingEntities.GetValueOrDefault(entry.Entity.GetType(), Array.Empty<string>());
            foreach (var member in entry.Members.Where(x => trackingPropertyNames.Contains(x.Metadata.Name)))
            {
                if (member.CurrentValue != entry.OriginalValues[member.Metadata.Name])
                {
                    var entity = entry.Entity;
                    var change = new ChangeHistory
                    {
                        Id = Guid.NewGuid(),
                        EntityId = entity.Id,
                        EntityName = entity.GetType().Name,
                        PropertyName = member.Metadata.Name,
                        Value = member.CurrentValue?.ToString() ?? string.Empty,
                        UpdatedAt = entity.UpdatedAt,
                        UpdatedById = entity.UpdatedById
                    };
                    dbContext.Set<ChangeHistory>().Add(change);
                }
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}