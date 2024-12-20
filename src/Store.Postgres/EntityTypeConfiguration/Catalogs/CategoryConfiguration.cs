using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false); 
        
        builder.HasMany<Product>()
            .WithOne()
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasIndex(entity => entity.Name).IsUnique();

        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength).IsRequired();
    }
}