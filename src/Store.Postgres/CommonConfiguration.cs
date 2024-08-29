using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EntityAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres;

internal static class CommonConfiguration
{
    public static EntityTypeBuilder<TEntity> ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IEntity
    {
        builder.HasKey(entity => entity.Id);
        return builder;
    }

    /// <summary>
    /// Сконфигурировать <see cref="SmartEnumeration{TEnum}"/> перечисление, как обычное.
    /// </summary>
    public static PropertyBuilder<TEntity> ConfigureSmartEnumerationAsEnum<TEntity>(this PropertyBuilder<TEntity> builder)
        where TEntity : SmartEnumeration<TEntity> =>
        builder.HasConversion(p => p.Value, p => SmartEnumeration<TEntity>.FromValue(p));
}