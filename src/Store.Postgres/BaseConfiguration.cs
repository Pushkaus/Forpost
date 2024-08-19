using Forpost.Common.EntityAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres;

public static class BaseConfiguration
{
    public static EntityTypeBuilder<TEntity> ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IEntity
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        return builder;
    }
}