using Forpost.Domain.Catalogs.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength).IsRequired();
    }
}