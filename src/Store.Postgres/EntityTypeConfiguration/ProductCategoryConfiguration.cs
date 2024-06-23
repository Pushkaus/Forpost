using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductCategoryConfiguration: IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasOne(entity => entity.RootCategory)
            .WithMany(entity => entity.DescendantCategories)
            .HasForeignKey(entity => entity.RootId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.ParentCategory)
            .WithMany(entity => entity.ChildCategories)
            .HasForeignKey(entity => entity.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}