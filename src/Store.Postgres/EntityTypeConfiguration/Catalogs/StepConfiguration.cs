using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Domain.Catalogs.TechCards.Steps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class StepConfiguration : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Operation>()
            .WithMany()
            .HasForeignKey(entity => entity.OperationId);

        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}