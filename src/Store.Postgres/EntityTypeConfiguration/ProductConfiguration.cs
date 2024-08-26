using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(key => key.CategoryId);

        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}