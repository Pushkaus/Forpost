using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class TechCardOperationConfiguration : IEntityTypeConfiguration<TechCardOperation>
{
    public void Configure(EntityTypeBuilder<TechCardOperation> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<TechCard>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);

        builder.HasOne<Operation>()
            .WithMany()
            .HasForeignKey(key => key.OperationId);
    }
}