using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class TechCardConfiguration : IEntityTypeConfiguration<TechCard>
{
    public void Configure(EntityTypeBuilder<TechCard> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(key => key.CreatedById);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(key => key.ProductId);
        builder.Property(entity => entity.Number).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}