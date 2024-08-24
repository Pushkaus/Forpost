using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class StepConfiguration : IEntityTypeConfiguration<StepEntity>
{
    public void Configure(EntityTypeBuilder<StepEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<OperationEntity>()
            .WithMany()
            .HasForeignKey(entity => entity.OperationId);

        builder.HasOne<TechCardEntity>()
            .WithMany()
            .HasForeignKey(key => key.TechCardId);
        
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);

    }
}