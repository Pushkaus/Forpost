using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<CategoryEntity>()
            .WithMany()
            .HasForeignKey(key => key.CategoryId);
        
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}