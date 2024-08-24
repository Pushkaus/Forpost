using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class ProductDevelopmentConfiguration: IEntityTypeConfiguration<ProductDevelopmentEntity>
{
    public void Configure(EntityTypeBuilder<ProductDevelopmentEntity> builder)
    {
        builder.ConfigureBaseEntity();
    }
}