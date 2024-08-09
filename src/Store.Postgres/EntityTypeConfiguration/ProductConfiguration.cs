using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasMany(p => p.ParentSubProducts)
            .WithOne(sub => sub.ParentProduct)
            .HasForeignKey(sub => sub.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.DaughterSubProducts)
            .WithOne(sub => sub.DaughterProduct)
            .HasForeignKey(sub => sub.DaughterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(entity => entity.InvoiceProducts)
            .WithOne(entity => entity.Product)
            .HasForeignKey(entity => entity.ProductId);
        
        builder.HasMany(entity => entity.Version)
            .WithOne(entity => entity.Product)
            .HasForeignKey(entity => entity.ProductId);
        
        
    }
}