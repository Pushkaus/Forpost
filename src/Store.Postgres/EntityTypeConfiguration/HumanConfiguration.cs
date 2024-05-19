using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class HumanConfiguration: IEntityTypeConfiguration<OrderBlock>
{
    public void Configure(EntityTypeBuilder<OrderBlock> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasColumnName("Идентификатор");
    }
}