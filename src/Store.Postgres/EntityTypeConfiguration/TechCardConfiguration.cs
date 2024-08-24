using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardConfiguration : IEntityTypeConfiguration<TechCardEntity>
{
    public void Configure(EntityTypeBuilder<TechCardEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<EmployeeEntity>()
            .WithMany()
            .HasForeignKey(key => key.CreatedById);

        builder.HasOne<ProductEntity>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
        builder.Property(entity => entity.Number).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}