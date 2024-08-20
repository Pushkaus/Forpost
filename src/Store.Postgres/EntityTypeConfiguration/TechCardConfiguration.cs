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
            .WithOne()
            .HasForeignKey<TechCard>(key => key.CreatedById);

        builder.HasOne<Product>()
            .WithOne()
            .HasForeignKey<TechCard>(key => key.ProductId);
        builder.Property(entity => entity.Number).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLenght);

    }
}