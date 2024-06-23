using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasOne(entity => entity.ProductCategory)
            .WithOne(category => category.Product)
            .HasForeignKey<Product>(entity => entity.ProductCategoryId)
            .IsRequired();
        
    }   
}