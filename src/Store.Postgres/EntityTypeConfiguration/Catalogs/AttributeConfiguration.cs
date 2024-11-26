using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = Forpost.Domain.Catalogs.Products.Attributes.Attribute;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class AttributeConfiguration: IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(x => x.PossibleValuesJson).HasColumnType("jsonb");
    }
}